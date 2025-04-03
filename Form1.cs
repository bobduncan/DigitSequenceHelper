using IronOcr;

namespace DigitSequenceHelper
{
    public partial class Form1 : Form
    {
        private const int FlowLayoutPanelInputWidth = 900;
        private const int FlowLayoutPanelInputHeight = 50;
        private const int TextBoxWidth = 50;

        public Form1()
        {
            InitializeComponent();
            InitializeDynamicTextBoxes();
            InitializeImageParsing();
        }

        #region Image Parsing

        private void InitializeImageParsing()
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V
                && Clipboard.ContainsImage())
            {
                Image image = Clipboard.GetImage();
                pictureBox1.Image = image;
                ParseImage();
            }
        }

        private void ParseImage()
        {
            var ocr = new IronTesseract();

            using var ocrInput = new OcrInput();
            ocrInput.LoadImage(pictureBox1.Image);
            // Optionally Apply Filters if needed:
            // ocrInput.Deskew();  // use only if image not straight
            // ocrInput.DeNoise(); // use only if image contains digital noise

            var ocrResult = ocr.Read(ocrInput);
            var rawText = ocrResult.Text;
            var filteredText = rawText
                .Replace("***** Unlock full functionality with an instant Free Trial Key *****", "")
                .Replace("***** https://ironsoftware.com/csharp/ocr/#trial-license *****", "")
                .Replace("***** See how to apply your key at  Please see how to apply one at https://ironsoftware.com/csharp/ocr/how-to/license-keys/ *****", "");
            richTextBox1.Text = filteredText;
        }


        #endregion

        #region Dynamic TextBoxes

        private void InitializeDynamicTextBoxes()
        {
            flowLayoutPanel1.BackColor = Color.LightGray;

            TextBox initialTextBox = CreateDynamicTextBox();
            flowLayoutPanelStart.Controls.Add(new Label { Width = TextBoxWidth });
            flowLayoutPanelStart.Controls.Add(initialTextBox);
        }

        private TextBox CreateDynamicTextBox()
        {
            TextBox textBox = new()
            {
                Width = TextBoxWidth // Set a desired width
            };
            textBox.TextChanged += DynamicTextBox_TextChanged;
            return textBox;
        }

        private void DynamicTextBox_TextChanged(object sender, EventArgs e)
        {
            if (sender is not TextBox currentTextBox)
                return;

            // Check if currentTextBox is the last control and is not empty.
            if (flowLayoutPanelStart.Controls.IndexOf(currentTextBox) == flowLayoutPanelStart.Controls.Count - 1 &&
                !string.IsNullOrWhiteSpace(currentTextBox.Text))
            {
                if (currentTextBox.Text != "?")
                {
                    // Add a new TextBox.
                    TextBox newTextBox = CreateDynamicTextBox();
                    flowLayoutPanelStart.Controls.Add(newTextBox);
                }
                else
                {
                    flowLayoutPanel1.Controls.Clear();
                    flowLayoutPanel1.Height = 0;
                    Analyse();
                }
            }
        }

        private void ResetUI()
        {
            flowLayoutPanelStart.Controls.Clear();
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Height = 0;
            InitializeDynamicTextBoxes();
        }

        #endregion

        private void Analyse()
        {
            var sequence = GetSequence();
            var analyserResults = Configuration.Analysers.Select(a =>
            {
                return a.Analyze(sequence);
            });

            analyserResults.Where(analysers => analysers?.Results != null && analysers.Results.Any(x => x != null))
                .ToList()
                .ForEach(x =>
                {
                    var flatResults = new FlowLayoutPanel
                    {
                        Width = FlowLayoutPanelInputWidth,
                        Height = FlowLayoutPanelInputHeight,
                        BackColor = Color.LightGray
                    };

                    flowLayoutPanel1.Controls.Add(flatResults);
                    flowLayoutPanel1.Height += FlowLayoutPanelInputHeight;

                    var emptyPlaceHolderLabel = new Label
                    {
                        Text = x.Analyser.OperationName,
                        Width = TextBoxWidth + TextBoxWidth / 2
                    };
                    flatResults.Controls.Add(emptyPlaceHolderLabel);

                    x.Results!.ForEach(result =>
                    {
                        if (result != null)
                        {
                            var label = new Label
                            {
                                Text = result.DisplayValue ?? string.Empty,
                                Width = TextBoxWidth
                            };

                            flatResults.Controls.Add(label);
                        }
                    });

                    if (x.PredictedNumber != null)
                    {
                        var label = new Label
                        {
                            Text = x.PredictedNumber.ToString(),
                            BackColor = Color.LightGreen,
                            Width = TextBoxWidth,
                            Margin = new Padding(TextBoxWidth / 2, 0, 0, 0)
                        };

                        flatResults.Controls.Add(label);
                    }

                });
        }

        private List<double> GetSequence()
        {
            List<double> numbers = [];

            foreach (Control control in flowLayoutPanelStart.Controls)
            {
                if (control is TextBox textBox
                    && int.TryParse(textBox.Text, out int value))
                {
                    numbers.Add(value);
                }
            }
            return numbers;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            ResetUI();
        }
    }
}
