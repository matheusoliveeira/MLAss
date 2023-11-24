using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Microsoft.ML.Trainers.FastTree;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using static AssignmentML.MLModel1;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AssignmentML
{
    public partial class Form1 : Form
    {
        private MLModel1.ModelInput currentSampleData;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Load sample data
            var sampleData = new MLModel1.ModelInput()
            {
                Col0 = textBoxFeedback.Text,

            };

            // Store the current sample data
            currentSampleData = sampleData;

            // Load model and predict output
            var result = MLModel1.Predict(sampleData);

            lblguess.Text = result.PredictedLabel.ToString();
            lblconfidence.Text = (result.Score[0] * 100).ToString("F2");

        }

        private void button2_Click(object sender, EventArgs e)
        {

            var selectedComboBox = comboBox1.GetItemText(comboBox1.SelectedItem);
            string feedback = textBoxFeedback.Text;
            string current = lblguess.Text;

            // Create MLContext
            MLContext mlContext = new MLContext();

            if (selectedComboBox == "0" || selectedComboBox == "1")
            {
                // Train and Save Model
                TrainAndSaveModel(mlContext, current, feedback);

                // Retrain model
                RetrainModel(mlContext, selectedComboBox, current, feedback);
            }
            else
            {
                MessageBox.Show("You need to select a value for retraining");
            }


        }
        // Method to handle retraining
        private RetrainResult RetrainModel(MLContext mlContext, string nValue, string oValue, string feedback)
        {
            // New data
            int newValue = Int32.Parse(nValue);
            float oldValue = (float)Int32.Parse(oValue);

            // Load saved data prep pipeline
            ITransformer dataPrepPipeline = mlContext.Model.Load("data_preparation_pipeline.zip", out DataViewSchema dataPrepPipelineSchema);

            // Load trained model
            ITransformer trainedModel = mlContext.Model.Load("ogd_model.zip", out DataViewSchema modelSchema);

            // Extract trained model parameters
            LinearRegressionModelParameters originalModelParameters = ((ISingleFeaturePredictionTransformer<object>)trainedModel).Model as LinearRegressionModelParameters;

            // Create new data

            ReviewData[] newDataArray = new ReviewData[]
            {
                // Populate with your new data
                new ReviewData
                {
                    col0 = feedback,
                    col1 = newValue,
                    CurrentGuess = oldValue
                }
            };

            // Load new data into an IDataView
            IDataView newData = mlContext.Data.LoadFromEnumerable<ReviewData>(newDataArray);

            // Apply data prep transforms to new data
            IDataView transformedNewData = dataPrepPipeline.Transform(newData);

            // Use the new data to train a new model
            var retrainedModel = mlContext.Regression.Trainers.OnlineGradientDescent().Fit(transformedNewData, originalModelParameters);

            // Extract Model Parameters of retrained model
            LinearRegressionModelParameters retrainedModelParameters = retrainedModel.Model as LinearRegressionModelParameters;

            // Inspect change in weights after retraining
            var weightDiffs = originalModelParameters.Weights.Zip(retrainedModelParameters.Weights, (original, retrained) => original - retrained).ToArray();

            System.Diagnostics.Debug.WriteLine("Original | Retrained | Difference");
            for (int i = 0; i < weightDiffs.Count(); i++)
            {
                System.Diagnostics.Debug.WriteLine($"{originalModelParameters.Weights[i]} | {retrainedModelParameters.Weights[i]} | {weightDiffs[i]}");
            }

            // Return both weightDiffs and originalModelParameters
            return new RetrainResult
            {
                WeightDiffs = weightDiffs,
                OriginalModelParameters = originalModelParameters,
                RetrainedModelParameters = retrainedModelParameters
            };
        }


        public class ReviewData
        {
            [LoadColumn(0)]
            public string col0 { get; set; } = string.Empty;

            [LoadColumn(1)]
            public int col1 { get; set; }

            [ColumnName("Label")]
            public float CurrentGuess { get; set; }
        }

        static void TrainAndSaveModel(MLContext mlContext, string currentValue, string feedback)
        {
            // New data
            int intValue = Int32.Parse(currentValue);
            float floatValue = (float)intValue;

            ReviewData[] newDataArray = new ReviewData[]
            {
                // Populate with your new data
                new ReviewData
                {
                    col0 = feedback,
                    col1 = intValue,
                    CurrentGuess = floatValue
                }
            };

            // Load Data
            IDataView data = mlContext.Data.LoadFromEnumerable<ReviewData>(newDataArray);

            IEstimator<ITransformer> dataPrepPipeline = BuildPipeline(mlContext);

            // Fir data preparation estimator to data
            ITransformer preprocessor = dataPrepPipeline.Fit(data);

            // Define model training pipeline
            var trainingPipeline = mlContext.Regression.Trainers.OnlineGradientDescent();

            // Preprocess data
            IDataView preprocessedData = preprocessor.Transform(data);

            // Train model
            ITransformer trainedModel = trainingPipeline.Fit(preprocessedData);

            // Save data preparation pipeline
            mlContext.Model.Save(preprocessor, data.Schema, "data_preparation_pipeline.zip");

            // Save trained model
            mlContext.Model.Save(trainedModel, preprocessedData.Schema, "ogd_model.zip");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var selectedComboBox = comboBox1.GetItemText(comboBox1.SelectedItem);
            string feedback = textBoxFeedback.Text;
            string current = lblguess.Text;

            // Create MLContext
            MLContext mlContext = new MLContext();

            // Call RetrainModel to get weight differences
            RetrainResult result = RetrainModel(mlContext, selectedComboBox, current, feedback);

            LinearRegressionModelParameters originalModelParameters = result.OriginalModelParameters;
            LinearRegressionModelParameters retrainedModelParameters = result.RetrainedModelParameters;
            float[] weightDiffs = result.WeightDiffs;


            label3.Text = originalModelParameters.Weights[0].ToString("F2");
            label4.Text = retrainedModelParameters.Weights[0].ToString("F2");
            label5.Text = weightDiffs[0].ToString("F2");
        }



        public class RetrainResult
        {
            public float[] WeightDiffs { get; set; }
            public LinearRegressionModelParameters OriginalModelParameters { get; set; }
            public LinearRegressionModelParameters RetrainedModelParameters { get; set; }

        }
    }
}