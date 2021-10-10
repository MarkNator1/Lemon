using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lemon1
{
    public partial class Lemon : Form
    {
        public static int list_control;
        public static int list_control_enc;
        public static char[] characters;

        public Lemon()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------------

        private void BtnCalcular_Click(object sender, EventArgs e)
        {
            characters = textBox4.Text.ToArray();


            if (characters.Length == 0)
            {
                MessageBox.Show("Desculpe, não foi possível Descriptar :(\nTalvez você tenha esquecido de escrever as informações :)");
            }
            else
            {
                textBox6.Text = Decrypted(characters);
            }
        }

        //-------------------------------------------------------------------------------------

        private void BtnEncrypt_Click_1(object sender, EventArgs e)
        {
            characters = textBox5.Text.ToArray();

            if(characters.Length == 0)
            {
                MessageBox.Show("Desculpe, não foi possível Encriptar :(\nTalvez você tenha esquecido de escrever as informações :)");
            }
            else
            {
                textBox6.Text = Encrypted_Enc(characters);
            }
        }

        //-------------------------------------------------------------------------------------

        public static char FirstChar_Enc() //Pega o primeiro caractere do texto que indica que lista usar para descripto ou cripto.
        {
            Random random = new Random();

            int random_n;
            random_n = random.Next(1, 6);
            char first_char = ' ';

            if (random_n == 1)
            {
                first_char = '#';
            }
            else if (random_n == 2)
            {
                first_char = '\"';
            }
            else if (random_n == 3)
            {
                first_char = '!';
            }
            else if (random_n == 4)
            {
                first_char = '@';
            }
            else if (random_n == 5)
            {
                first_char = '%';
            }
            else if (random_n == 6)
            {
                first_char = '$';
            }

            return first_char;
        }

        //-------------------------------------------------------------------------------------

        public static string Encrypted_Enc(params char[] i_chars)
        {
            string encrypted_txt;
            encrypted_txt = FirstChar_Enc().ToString();

            if(FirstChar_Enc() == '!')
            {
                list_control_enc = 3;
            }
            else if(FirstChar_Enc() == '\"')
            {
                list_control_enc = 2;
            }
            else if (FirstChar_Enc() == '@')
            {
                list_control_enc = 4;
            }
            else if (FirstChar_Enc() == '#')
            {
                list_control_enc = 1;
            }
            else if (FirstChar_Enc() == '$')
            {
                list_control_enc = 6;
            }
            else if (FirstChar_Enc() == '%')
            {
                list_control_enc = 5;
            }

            encrypted_txt += Encrypt_Enc(i_chars);

            return encrypted_txt;

        }

        //-------------------------------------------------------------------------------------

        public static string Encrypt_Enc(char[] in_chars)
        {
            string encrypted_txt = "";

            for (int i = 0; i < in_chars.Length; i++)
            {
                encrypted_txt += RetornaTxt_Enc(in_chars[i]);
            }

            return encrypted_txt;
        }

        //-------------------------------------------------------------------------------------

        static char RetornaTxt_Enc(char chars) //Pega a lista a qual se basear e retorna os caracteres criptografados de acordo com essa lista.
        {
            char[] chosen_list = new char[100];
            chosen_list = Lists(0);
            char letter = ' ';

            for (int i = 0; i < chosen_list.Length; i++)
            {
                if (chars == chosen_list[i])
                {
                    letter = Lists(list_control_enc)[i];
                }
            }

            return letter;
        }

        //-------------------------------------------------------------------------------------

        static string Decrypted(params char[] i_chars) //Pega os caracteres e imprime o texto descriptografado na tela.
        {
            string decrypted_txt = "";

            if (i_chars[0] == '!')
            {
                list_control = 3;
            }
            else if (i_chars[0] == '\"')
            {
                list_control = 2;
            }
            else if (i_chars[0] == '@')
            {
                list_control = 4;
            }
            else if (i_chars[0] == '#')
            {
                list_control = 1;
            }
            else if (i_chars[0] == '$')
            {
                list_control = 6;
            }
            else if (i_chars[0] == '%')
            {
                list_control = 5;
            }
            else
            {
                Console.WriteLine("\nDesculpa, acho que tem alguma coisa errada no código :(");
            }

            decrypted_txt = Decrypt(i_chars);

            return decrypted_txt;
        }
    
        //-------------------------------------------------------------------------------------

        static string Decrypt(char[] in_chars) //Pega todos os caracteres e descriptografa cada um deles.
            {

                string decrypted_txt = "";

                for (int i = 1; i < in_chars.Length; i++)
                {
                    decrypted_txt += RetornaTxt(in_chars[i]);
                }

                return decrypted_txt;
            }

        //-------------------------------------------------------------------------------------

        static char RetornaTxt(char chars) //Pega a lista a qual se basear e retorna os caracteres descriptografados de acordo com essa lista.
            {
                char[] chosen_list = new char[100];
                chosen_list = Lists(list_control);
                char letter = ' ';

                for (int i = 0; i < chosen_list.Length; i++)
                {
                    if (chars == chosen_list[i])
                    {
                        letter = Lists(0)[i];
                    }
                }

                return letter;
            }

        //-------------------------------------------------------------------------------------

        static char[] Lists(int index) //Retorna a lista a qual se basear para fazer a descriptografia/criptografia.
        {
            string[] lists = new string[10];

            char[] chosen_list = new char[100];

            lists[0] = "abcdefghijklmnopqrstuvwxyz!\"@#$%¨&*()_+\'¹²³£¢¬-=§/,.:;´`^~|\\><0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ\n"; //base
            lists[1] = "b|dK9\"LuXZz_%´5lUH¹/\\vBS,~tPj^Wg§¨.ne@MD+okcV);Q8N£-aq*sxFY<R$&\'3m`G!J:i7Af2wT(hIr=1¢p¬>²E#C06³4yO[";
            lists[2] = "ZrU6sYGQMV~´§z.\'NuoatE=0+m£;1R87b-qn)X/L5ic¹2w³j&gl\\|J¬$ph<C,O_Wy\"Hef>d¢`*vTSk:¨Fx@A3K^4#PB(²D9I!%]";
            lists[3] = "Rxv!lQ=`/6@2af3bL)AsVj<>¹£\"mU-,4eG5WN§~7CZ³hgPH^$¨1#Irwkp%S&Y*_u.8XMdtqJo(i9¬\\B+\'n:´z²¢DTO;Ey0cK|Fº";
            lists[4] = "elP¢+D6¹z²:OdCsE/@8X\\<m¨=&V.UTL0g\',wj^£*3bZF7np´!~t_NkRQ1B(I9r#oiAS\"³hJ|4ay25;HK%qWM$`-vuxf¬§Y>Gc)ª";
            lists[5] = "\"3$M£8y0a:g5²\\VD6H³dLE@§-lc¨*O)niW^=Zs<~´Xk_e2J\'K`1Yx>F|pqA!b7(NI#fz;jvPoU.9m¬%+rTCQuR¹h,wGtBS¢&/4{";
            lists[6] = "o;ZBeYKIM/`=+#u2´7Uy4t(F<Gs0p~¨Pj\'h³Dw:n§%\"lAz,²dqO@r)x56ka\\*.C£9E|&RvQJLmS¹b_¬Vg8H-TiW3!1¢>X$^fcN}";


            chosen_list = lists[index].ToArray();

            return chosen_list;
        }

        //-------------------------------------------------------------------------------------
    }
}

    
