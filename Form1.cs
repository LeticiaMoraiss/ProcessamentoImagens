using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessamentoImagens
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void carregarImagem1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                InputImgem1.ImageLocation = file.FileName;
            }
        }

        private void carregarImagem2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                InputImagem2.ImageLocation = file.FileName;
            }
        }

        private void InputNenhum_CheckedChanged(object sender, EventArgs e)
        {
            InputImagem3.Image = null;
        }

        /*=============================== Botões de conversão de Escalas ================================== */
        private void InputEscalaCinza_CheckedChanged(object sender, EventArgs e)
        {
            InputEscalaCinza.Invoke((MethodInvoker)delegate 
            {
                var path = Application.StartupPath + @"\Imagem\images.png";
                path = path.Replace("\\bin\\Debug", "");
                InputPictureBox4.Image = Image.FromFile(path);
            });
            Application.DoEvents();
            ConverterEscalaCinza();
            InputEscalaCinza.Invoke((MethodInvoker)delegate { InputPictureBox4.Visible = false; });
        }

        private void InputNegativo_CheckedChanged(object sender, EventArgs e)
        {
            InputNegativo.Invoke((MethodInvoker)delegate
            {
                var path = Application.StartupPath + @"\Imagem\images.png";
                path = path.Replace("\\bin\\Debug", "");
                InputPictureBox4.Image = Image.FromFile(path);
            });
            Application.DoEvents();
            ConverterNegativo();
            InputNegativo.Invoke((MethodInvoker)delegate { InputPictureBox4.Visible = false; });
        }

        private void InputPretoBranco_CheckedChanged(object sender, EventArgs e)
        {
            InputPretoBranco.Invoke((MethodInvoker)delegate
            {
                var path = Application.StartupPath + @"\Imagem\images.png";
                path = path.Replace("\\bin\\Debug", "");
                InputPictureBox4.Image = Image.FromFile(path);
            });
            Application.DoEvents();
            ConverterPretoBranco();
            InputPretoBranco.Invoke((MethodInvoker)delegate { InputPictureBox4.Visible = false; });
        }

        private void InputLimiar_ValueChanged(object sender, EventArgs e)
        {
            if (InputPretoBranco.Checked)
            {
                InputPretoBranco_CheckedChanged(sender, e);
            }
        }

        /*=============================== Botões de Operações Aritmeticas ================================== */
        private void InputSoma_CheckedChanged(object sender, EventArgs e)
        {
            InputSoma.Invoke((MethodInvoker)delegate
            {
                var path = Application.StartupPath + @"\Imagem\images.png";
                path = path.Replace("\\bin\\Debug", "");
                InputPictureBox4.Image = Image.FromFile(path);
            });
            Application.DoEvents();
            OperacaoSoma();
            InputSoma.Invoke((MethodInvoker)delegate { InputPictureBox4.Visible = false; });
        }

        private void InputSubtracao_CheckedChanged(object sender, EventArgs e)
        {
            InputSubtracao.Invoke((MethodInvoker)delegate
            {
                var path = Application.StartupPath + @"\Imagem\images.png";
                path = path.Replace("\\bin\\Debug", "");
                InputPictureBox4.Image = Image.FromFile(path);
            });
            Application.DoEvents();
            OperacaoSubtracao();
            InputSubtracao.Invoke((MethodInvoker)delegate { InputPictureBox4.Visible = false; });
        }

        private void InputMultipicacao_CheckedChanged(object sender, EventArgs e)
        {
            InputMultipicacao.Invoke((MethodInvoker)delegate
            {
                var path = Application.StartupPath + @"\Imagem\images.png";
                path = path.Replace("\\bin\\Debug", "");
                InputPictureBox4.Image = Image.FromFile(path);
            });
            Application.DoEvents();
            OperacaoMultiplicacao();
            InputMultipicacao.Invoke((MethodInvoker)delegate { InputPictureBox4.Visible = false; });
        }

        /*=============================== Botões de Operações Boleanas ================================== */
        private void InputAnd_CheckedChanged(object sender, EventArgs e)
        {
            InputAnd.Invoke((MethodInvoker)delegate
            {
                var path = Application.StartupPath + @"\Imagem\images.png";
                path = path.Replace("\\bin\\Debug", "");
                InputPictureBox4.Image = Image.FromFile(path);
            });
            Application.DoEvents();
            OperacaoAND();
            InputAnd.Invoke((MethodInvoker)delegate { InputPictureBox4.Visible = false; });
        }

        private void InputOr_CheckedChanged(object sender, EventArgs e)
        {
            InputOr.Invoke((MethodInvoker)delegate
            {
                var path = Application.StartupPath + @"\Imagem\images.png";
                path = path.Replace("\\bin\\Debug", "");
                InputPictureBox4.Image = Image.FromFile(path);
            });
            Application.DoEvents();
            OperacaoOR();
            InputOr.Invoke((MethodInvoker)delegate { InputPictureBox4.Visible = false; });
        }

        private void InputXor_CheckedChanged(object sender, EventArgs e)
        {
            InputXor.Invoke((MethodInvoker)delegate
            {
                var path = Application.StartupPath + @"\Imagem\images.png";
                path = path.Replace("\\bin\\Debug", "");
                InputPictureBox4.Image = Image.FromFile(path);
            });
            Application.DoEvents();
            OperacaoXOR();
            InputXor.Invoke((MethodInvoker)delegate { InputPictureBox4.Visible = false; });
        }
     
        /*=============================== Conversão de Escalas ================================== */
        private void ConverterEscalaCinza()
        {
            Bitmap original = new Bitmap(InputImgem1.Image);
            Bitmap novo = new Bitmap(original.Width, original.Height);
            for (int i = 0; i < original.Width; i++)
            {
                for (int j = 0; j < original.Height; j++)
                {
                    Color originalColor = original.GetPixel(i, j);//pega a cor original
                    int grayScale = (int)((originalColor.R * 0.3) + (originalColor.G * 0.59) + (originalColor.B * 0.11));
                    Color CorEmEscalaDeCinza = Color.FromArgb(grayScale, grayScale, grayScale);
                    novo.SetPixel(i, j, CorEmEscalaDeCinza);
                }
            }

            InputImagem3.Image = novo;
        }

        private void ConverterNegativo()
        {
            Bitmap original = new Bitmap(InputImgem1.Image);
            Bitmap novo = new Bitmap(original.Width, original.Height);
            for (int i = 0; i < original.Width; i++)
            {
                for (int j = 0; j < original.Height; j++)
                {
                    Color originalColor = original.GetPixel(i, j);//pega a cor original
                    Color CorEmNegativo = Color.FromArgb(255 - originalColor.R, 255 - originalColor.G, 255 - originalColor.B);
                    novo.SetPixel(i, j, CorEmNegativo);
                }
            }
            InputImagem3.Image = novo;
        }

        private void ConverterPretoBranco()
        {
            Bitmap original = new Bitmap(InputImgem1.Image);
            Bitmap novo = new Bitmap(original.Width, original.Height);
            Color CorEmPretoBranco;
            int limiar = Convert.ToInt32(InputLimiar.Value.ToString());

            for (int i = 0; i < original.Width; i++)
            {
                for (int j = 0; j < original.Height; j++)
                {
                    Color originalColor = original.GetPixel(i, j);//pega a cor original
                    int grayScale = (int)((originalColor.R * 0.3) + (originalColor.G * 0.59) + (originalColor.B * 0.11));
                    if (grayScale > limiar)
                    {
                        CorEmPretoBranco = Color.FromArgb(255, 255, 255);
                    }
                    else
                    {
                        CorEmPretoBranco = Color.FromArgb(0, 0, 0);
                    }
                    novo.SetPixel(i, j, CorEmPretoBranco);
                }
            }
            InputImagem3.Image = novo;
        }

        /*=============================== Operações Aritmeticas ================================== */
        private void OperacaoSoma()
        {
            Bitmap imagem1 = new Bitmap(InputImgem1.Image);
            Bitmap imagem2 = new Bitmap(InputImagem2.Image);

            Bitmap novo = new Bitmap(imagem1.Width, imagem1.Height);
            Color Soma;

            int[,] matriz = new int[imagem1.Width, imagem1.Height];

            int maior = 255;
            int menor = 0;

            for (int i = 0; i < imagem1.Width; i++)
            {
                for (int j = 0; j < imagem1.Height; j++)
                {
                    Color imagem1Color = imagem1.GetPixel(i, j);//pega a cor original
                    Color imagem2Color = imagem2.GetPixel(i, j);//pega a cor original

                    int pixel = (int)((imagem1Color.R + imagem1Color.G + imagem1Color.B) + (imagem2Color.R + imagem2Color.G + imagem2Color.B));

                    if (menor == 0)
                    {
                        menor = pixel;
                    }
                    if (pixel > maior)
                    {
                        maior = pixel;
                    }
                    else if (pixel < menor)
                    {
                        menor = pixel;
                    }

                    matriz[i, j] = pixel;
                }
            }

            if (maior > 255 || menor < 0)
            {

                for (int i = 0; i < novo.Width; i++)
                {
                    for (int j = 0; j < novo.Height; j++)
                    {
                        int pixel = matriz[i, j];

                        float div = maior - menor;
                        float mult = pixel - menor;
                        float px = (255 / div);
                        float auxPixel = px * mult;

                        Soma = Color.FromArgb(Convert.ToInt32(auxPixel), Convert.ToInt32(auxPixel), Convert.ToInt32(auxPixel));

                        novo.SetPixel(i, j, Soma);
                    }
                }
                InputImagem3.Image = novo;
            }
            else
            {
                for (int i = 0; i < novo.Width; i++)
                {
                    for (int j = 0; j < novo.Height; j++)
                    {
                        int pixel = matriz[i, j];

                        Soma = Color.FromArgb(pixel, pixel, pixel);

                        novo.SetPixel(i, j, Soma);
                    }
                }
                InputImagem3.Image = novo;
            }
        }

        private void OperacaoSubtracao()
        {
            Bitmap imagem1 = new Bitmap(InputImgem1.Image);
            Bitmap imagem2 = new Bitmap(InputImagem2.Image);

            Bitmap novo = new Bitmap(imagem1.Width, imagem1.Height);
            Color Soma;

            int[,] matriz = new int[imagem1.Width, imagem1.Height];

            int maior = 255;
            int menor = 0;

            for (int i = 0; i < imagem1.Width; i++)
            {
                for (int j = 0; j < imagem1.Height; j++)
                {
                    Color imagem1Color = imagem1.GetPixel(i, j);//pega a cor original
                    Color imagem2Color = imagem2.GetPixel(i, j);//pega a cor original

                    int pixel = (int)((imagem1Color.R + imagem1Color.G + imagem1Color.B) - (imagem2Color.R + imagem2Color.G + imagem2Color.B));

                    if (menor == 0)
                    {
                        menor = pixel;
                    }
                    if (pixel > maior)
                    {
                        maior = pixel;
                    }
                    else if (pixel < menor)
                    {
                        menor = pixel;
                    }

                    matriz[i, j] = pixel;
                }
            }

            if (maior > 255 || menor < 0)
            {

                for (int i = 0; i < novo.Width; i++)
                {
                    for (int j = 0; j < novo.Height; j++)
                    {
                        int pixel = matriz[i, j];

                        float div = maior - menor;
                        float mult = pixel - menor;
                        float px = (255 / div);
                        float auxPixel = px * mult;

                        Soma = Color.FromArgb(Convert.ToInt32(auxPixel), Convert.ToInt32(auxPixel), Convert.ToInt32(auxPixel));

                        novo.SetPixel(i, j, Soma);
                    }
                }
                InputImagem3.Image = novo;
            }
            else
            {
                for (int i = 0; i < novo.Width; i++)
                {
                    for (int j = 0; j < novo.Height; j++)
                    {
                        int pixel = matriz[i, j];

                        Soma = Color.FromArgb(pixel, pixel, pixel);

                        novo.SetPixel(i, j, Soma);
                    }
                }
                InputImagem3.Image = novo;
            }
        }

        private void OperacaoMultiplicacao()
        {
            Bitmap imagem1 = new Bitmap(InputImgem1.Image);
            Bitmap imagem2 = new Bitmap(InputImagem2.Image);

            Bitmap novo = new Bitmap(imagem1.Width, imagem1.Height);
            Color Soma;

            int[,] matriz = new int[imagem1.Width, imagem1.Height];

            int maior = 255;
            int menor = 0;

            for (int i = 0; i < imagem1.Width; i++)
            {
                for (int j = 0; j < imagem1.Height; j++)
                {
                    Color imagem1Color = imagem1.GetPixel(i, j);//pega a cor original
                    Color imagem2Color = imagem2.GetPixel(i, j);//pega a cor original

                    int pixel = (int)((imagem1Color.R + imagem1Color.G + imagem1Color.B) * (imagem2Color.R + imagem2Color.G + imagem2Color.B));

                    if (menor == 0)
                    {
                        menor = pixel;
                    }
                    if (pixel > maior)
                    {
                        maior = pixel;
                    }
                    else if (pixel < menor)
                    {
                        menor = pixel;
                    }

                    matriz[i, j] = pixel;
                }
            }

            if (maior > 255 || menor < 0)
            {

                for (int i = 0; i < novo.Width; i++)
                {
                    for (int j = 0; j < novo.Height; j++)
                    {
                        int pixel = matriz[i, j];

                        float div = maior - menor;
                        float mult = pixel - menor;
                        float px = (255 / div);
                        float auxPixel = px * mult;

                        Soma = Color.FromArgb(Convert.ToInt32(auxPixel), Convert.ToInt32(auxPixel), Convert.ToInt32(auxPixel));

                        novo.SetPixel(i, j, Soma);
                    }
                }
                InputImagem3.Image = novo;
            }
            else
            {
                for (int i = 0; i < novo.Width; i++)
                {
                    for (int j = 0; j < novo.Height; j++)
                    {
                        int pixel = matriz[i, j];

                        Soma = Color.FromArgb(pixel, pixel, pixel);

                        novo.SetPixel(i, j, Soma);
                    }
                }
                InputImagem3.Image = novo;
            }
        }

        /*=============================== Operações Boleanas ================================== */
        public void OperacaoAND()
        {
            Bitmap imagem1 = new Bitmap(InputImgem1.Image);
            Bitmap imagem2 = new Bitmap(InputImagem2.Image);

            Bitmap novo = new Bitmap(imagem1.Width, imagem1.Height);

            for (int i = 0; i < imagem1.Width; i++)
            {
                for (int j = 0; j < imagem1.Height; j++)
                {
                    Color imagem1Color = imagem1.GetPixel(i, j);//pega a cor original
                    Color imagem2Color = imagem2.GetPixel(i, j);//pega a cor original
                    Color AND = Color.FromArgb((imagem1Color.R & imagem2Color.R), (imagem1Color.G & imagem2Color.G), (imagem1Color.B & imagem2Color.B));
                    novo.SetPixel(i, j, AND);
                }
            }
            InputImagem3.Image = novo;
        }

        public void OperacaoOR()
        {
            Bitmap imagem1 = new Bitmap(InputImgem1.Image);
            Bitmap imagem2 = new Bitmap(InputImagem2.Image);

            Bitmap novo = new Bitmap(imagem1.Width, imagem1.Height);

            for (int i = 0; i < imagem1.Width; i++)
            {
                for (int j = 0; j < imagem1.Height; j++)
                {
                    Color imagem1Color = imagem1.GetPixel(i, j);//pega a cor original
                    Color imagem2Color = imagem2.GetPixel(i, j);//pega a cor original
                    Color OR = Color.FromArgb((imagem1Color.R | imagem2Color.R), (imagem1Color.G | imagem2Color.G), (imagem1Color.B | imagem2Color.B));
                    novo.SetPixel(i, j, OR);
                }
            }
            InputImagem3.Image = novo;
        }

        public void OperacaoXOR()
        {
            Bitmap imagem1 = new Bitmap(InputImgem1.Image);
            Bitmap imagem2 = new Bitmap(InputImagem2.Image);

            Bitmap novo = new Bitmap(imagem1.Width, imagem1.Height);

            for (int i = 0; i < imagem1.Width; i++)
            {
                for (int j = 0; j < imagem1.Height; j++)
                {
                    Color imagem1Color = imagem1.GetPixel(i, j);//pega a cor original
                    Color imagem2Color = imagem2.GetPixel(i, j);//pega a cor original
                    Color XOR = Color.FromArgb((imagem1Color.R ^ imagem2Color.R), (imagem1Color.G ^ imagem2Color.G), (imagem1Color.B ^ imagem2Color.B));
                    novo.SetPixel(i, j, XOR);
                }
            }
            InputImagem3.Image = novo;
        }
    }
}
