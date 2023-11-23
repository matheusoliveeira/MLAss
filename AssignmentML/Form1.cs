namespace AssignmentML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Load sample data
            var sampleData = new MLModel1.ModelInput()
            {
                Col0 = @"Crust is not good.",
            };

            //Load model and predict output
            var result = MLModel1.Predict(sampleData);
        }
    }
}