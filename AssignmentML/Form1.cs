using Microsoft.ML;
using System.Windows.Forms;
using static AssignmentML.MLModel1;

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

            // Check if the feedback is bad (0), and trigger retraining if needed
            if (result.PredictedLabel == 0)
            {
                // You can provide feedback to the user or call a method to initiate retraining
                MessageBox.Show("The model predicts the feedback as bad. You may consider retraining.");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RetrainModel();
        }

        // Method to handle retraining
        private void RetrainModel()
        {
            // Check if there is a sample data for retraining
            if (currentSampleData != null)
            {
                // TODO: Implement retraining logic using currentSampleData
                // You need to implement your retraining logic here based on your requirements.
                // You can use ML.NET's retraining techniques similar to the previous examples.
                // For simplicity, let's assume a method RetrainModel is implemented for retraining.
                // RetrainModel(currentSampleData);
            }
            else
            {
                MessageBox.Show("No sample data available for retraining.");
            }
        }
    }
}


//select number from combobox

//click re-train

//create a copy model of the current feedback

//store somehow the weights of current and re-trained model

//call compare models and display weights and  difference

//https://learn.microsoft.com/en-us/dotnet/machine-learning/how-to-guides/retrain-model-ml-net