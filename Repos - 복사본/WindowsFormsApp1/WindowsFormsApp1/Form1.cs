using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Formtest1 : Form
    {
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(string Section, string key, string def, StringBuilder sb, int size, string path);
        //StringBuilder sb, int size = 워킹버퍼 path = ini  파일의 위치
        [DllImport("kernel32.dll")]
        private static extern int WritePrivateProfileString(string Section, string key, string val, string path);

        public Formtest1() //class가 시행 될 때 처음 생기는 생성자 = public
        {
            InitializeComponent();
            radioButton1.Checked = true; //이벤트 핸들러
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //label1.Text = textBox1.Text;

            string str = textBox1.Text.Replace("yujin", "유진");

            if (checkBox1.Checked)//true,false,a>0, b==1 //소문자로 바꾸어서 label1에 출력
            {
                str = textBox1.Text.Replace("yujin", "유진");
                //str = textBox1.Text.ToLower();
                label1.Text = str;
            }
            //if (checkbox2.checked)
            //{
            //        str = textbox1.text.toupper();
            //        label2.text = str;
            //    }

        }

        private void btncombo_Click(object sender, EventArgs e)
        {
            //tbcombo.Text : input number : 정수입력
            //ComboBox 에 아이템 추가
            string str = tbcombo.Text;

            //텍스트상자가 공백이면 아무동작도 하지 않음
            if (tbcombo.Text == "")
            { }
            //** 입력한거랑 이미 같은 목록일때 입력 안하는 거 해보기** //
            //텍스트 상자가 공백이 아니면 입력함
            else
            {
                comboBox1.Items.Add(str);
                tbcombo.Text = "";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*string com = comboBox2.Text;
            int com2 = int.Parse(com);
            string ss = GetToken(sStr, ",", com2);
            tbTest.Text = ss;*/

            int n = int.Parse(comboBox2.Text);//combox 창에 표시된 문자열  
            int m = int.Parse(comboBox2.Items[comboBox2.SelectedIndex].ToString());
            tbTest.Text = GetToken(sStr, ",", n);
        }

        string sStr; //Global variable , 앞에 private 이나 public 안붙으면 class 속성을 가진다
        /*     함수명 :  GetToken : 인수로 주어진 문자열에 대하여 주어진 구분자로 구분되는 필드의 n번째 데이터를 추출하여 되돌려 주는 일반 함수
                인수(Argument) (string str, string seperator, int field index)
                                    str : 대상 문자열 
                                    seperator : 구분자
                                    field_index: 구분자로 열견되는 필드 번호
                return : string sRet
                             sRet : 추출된 문자 데이터
                해당하는 데이터가 없을 경우 ""(빈 문자열을) 반환
                error: 발생 가능한 모든 에러를 예상하여 회피할 수 있도록 프로그래밍한다 (debugging 을 통해 bug fix)*/
        public string GetToken(string str, string sep, int n)
        {

            /*
                string ss = GetToken(sStr,",",3);
                for 루프를 사용하여 n번째 구분자를 탐색
                str = "0kim,1le,2han,3seo,4cho,5cha" sep = "," n = 3  (index가 3인 것의 데이터)
                ret = "3seo"
                 n번째 구분자 이후 n+1번째 구분자 탐색
                문자열 길이 계산 int len = sStr.Length;
                문자열 추출: Substirng 메서드 이용*/
            int i;
            int n1 = 0, n2 = 0, n3 = 0;
            string sRet;
            for (i = 0, n1 = 0, n2 = 0; i < n; i++)
            //초기값, 수행조건,증감연산
            //for 루프의 경계값 : 시작 i = 0 , 종료 i = n;
            {
                n1 = str.IndexOf(sep, n1) + 1; //i번째 구분자
                                               //indexOf: 문자가 없을 경우 -1 (n을 str 갯수보다 더 많이 입력했을 때)
                if (n1 == 0) return "";
            } // n1; // n번째 필드 시작
            n2 = str.IndexOf(sep, n1); //n+1 번째 구분자
            if (n2 == -1) n2 = str.Length; //
            n3 = n2 - n1; //문자열 길이 계산
            sRet = str.Substring(n1, n3);
            return sRet;
        }
        int cn1, cn2, cn3, cn4, cn5; //form2 의 combobox 설정값 보관용

        string sPath = @".\WinApp1.ini"; //백슬래시( \ ) 뒤에 한 문자나 숫자 조합이 오는 문자 조합을 "이스케이프 시퀀스"라고 함
                                         //알파@를 붙여주면 이를 무시하게 됨
                                         //함수의 일반화 # 2 - GetiniInt(string section, string key);
                                         //인수 (Arg) section : ini 파일의 Section 이름
                                         // key : key 이름
                                         //def:default int value
                                         // return : nValue: ini파일에 읽은 추출한 파라미터 값 ( int )

        //함수의 일반화#3 - GetInI_string(string section, string key, int def)
        public string GetInI_String(string sec, string key)
        {
            StringBuilder sb = new StringBuilder();
            GetPrivateProfileString(sec, key, "",sb, 500, sPath);
            return sb.ToString();
        }
        public int GetInI_Int(string sec, string key, int def =0 )//함수선언부에서 def=0으로 아예 값설정 가능,그렇지만 추후 수정하면 수정한 대로 값 이용 가능
        {
            StringBuilder sb = new StringBuilder();
            GetPrivateProfileString(sec, key, $"{def}", sb, 500, sPath);
            //GetPrivateProfileString("Form2 Combo Set", "cn2", "0", sb, 500, sPath); cn2 = int.Parse(sb.ToString());
            //GetPrivateProfileString(string Section, string key, string def, StringBuilder sb, int size, string path);

            int nVal = int.Parse(sb.ToString()); //sb를 string으로 바꿔준 다음 다시 int로 파싱

            return nVal;
        }
        

        private void Formtest1_Load(object sender, EventArgs e) // form1불러올 때 지난번에 저장했던 데이터 불러오기 get
        {

            StringBuilder sb = new StringBuilder();
            // 문자열이 빈번히 갱신되는 프로그램에는 Mutable타입인 StringBuilder 클래스를 

            //StringBuilder sb = new StringBuilder(); //sb는 값을 불러올때만 필요함

            cn1 = GetInI_Int("Form2 Combo Set", "cn1");
            cn2 = GetInI_Int("Form2 Combo Set", "cn2");
            cn3 = GetInI_Int("Form2 Combo Set", "cn3");
            cn4 = GetInI_Int("Form2 Combo Set", "cn4");
            cn5 = GetInI_Int("Form2 Combo Set", "cn5");

            GetPrivateProfileString("Form1 tbTest", "as1", "0", sb, 500, sPath);

            tbTest.Text = GetInI_String("Form1 tbTest Set", "tbTest.Text");

            //GetPrivateProfileString("Form2 Combo Set", "cn1", "0", sb, 500, sPath); cn1 = int.Parse(sb.ToString()); 
            /*원래 cn1 = GetPrivateProfileString("Form2 Combo Set", "cn1", "0", sb, 500, sPath) 이렇게 해서 cn1에 값을
            넣어줘야하는데 GetPrivateProfileString("Form2 Combo Set", "cn1", "0", sb, 500, sPath)이게 문자열이어서 
            int.Parse(sb.ToString())이걸 통해서 숫자로 바꿔서 cn1= int.Parse(sb.ToString()) 이렇게 넣어주는 거였는데
            지금 함수는 바로 return 해서 int로 결과값이 나오니까 cn1 = Getini_Int("Form2 Combo Set", "cn1",0);으로 바로 들어가는 
            거임*/
            //GetPrivateProfileString("Form2 Combo Set", "cn2", "0", sb, 500, sPath); cn2 = int.Parse(sb.ToString());
            //GetPrivateProfileString("Form2 Combo Set", "cn3", "0", sb, 500, sPath); cn3 = int.Parse(sb.ToString());
            //GetPrivateProfileString("Form2 Combo Set", "cn4", "0", sb, 500, sPath); cn4 = int.Parse(sb.ToString());
            //GetPrivateProfileString("Form2 Combo Set", "cn5", "0", sb, 500, sPath); cn5 = int.Parse(sb.ToString());

            this.Width = GetInI_Int("form1 Size Set" ,"width", 1000);
            this.Height = GetInI_Int("form1 Size Set" ,"height", 700);

            //GetPrivateProfileString("Form1 Size Set", "width", "1000", sb, 500, sPath); this.Width = int.Parse(sb.ToString());
           // GetPrivateProfileString("Form1 Size Set", "height", "800", sb, 500, sPath); this.Height = int.Parse(sb.ToString());

        }

        private void Formtest1_FormClosed(object sender, FormClosedEventArgs e) //닫을 때 form2 콤보박스 안에 있는 데이터 저장 write
        {

            WritePrivateProfileString("Form2 Combo Set", "cn1", string.Format("{0}", cn1), sPath);
            WritePrivateProfileString("Form2 Combo Set", "cn2", string.Format("{0}", cn2), sPath);
            WritePrivateProfileString("Form2 Combo Set", "cn3", string.Format("{0}", cn3), sPath);
            WritePrivateProfileString("Form2 Combo Set", "cn4", string.Format("{0}", cn4), sPath);
            WritePrivateProfileString("Form2 Combo Set", "cn5", string.Format("{0}", cn5), sPath);//$"{cn1}" = string.Format("{0}",cn1)==>보관문자열처리

            WritePrivateProfileString("Form1 Size Set", "width", $"{this.Width}", sPath);
            WritePrivateProfileString("Form1 Size Set", "height", $"{this.Height}", sPath);
           
            WritePrivateProfileString("Form1 tbTest Set", "tbTest.Text",tbTest.Text, sPath);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 dlg = new Form2();//Local variable
            dlg.cn1 = cn1;//오른쪽에서 왼쪽으로 값을 넣는다 
            dlg.cn2 = cn2;
            dlg.cn3 = cn3;
            dlg.cn4 = cn4;
            dlg.cn5 = cn5;
            DialogResult dr = dlg.ShowDialog();
            if (dr == DialogResult.OK)
            {
                cn1 = dlg.cn1;
                cn2 = dlg.cn2;
                cn3 = dlg.cn3;
                cn4 = dlg.cn4;
                cn5 = dlg.cn5;
                sStr = string.Format("{0},{1},{2},{3},{4}", dlg.as1, dlg.as2, dlg.as3, dlg.as4, dlg.as5); //쌍따옴표 안에 있는 중괄호 인덱서에 as1,as2,as3,as4 (argument)가 들어간다 
                MessageBox.Show(sStr);
                tbTest.Text = sStr;
                btnNoop.Text = "Ready";
            }
        }



        private void btnNoop_Click(object sender, EventArgs e)
        {
            if (btnNoop.Text == "Ready")
            {
                //이름만 추출하세요. 첫번째와 두번째 ',' 사이에 있음
                //string.indexof() / string.SubString()

                //int lng = dlg.as2.Length; << 이건 Form2 dlg = new Form2(); 를 전역변수로 해야함 (현재는 지역함수)
                /* 알고리즘 구상
                 - 구분자(",")가 위치한 첫번째 인덱스 찾기
                 - 구분자(",")가 위치한 두번째 인덱스 찾기
                구분할 문자열 길이는 n2-n1-1*/
            /*
             int n1 = sStr.IndexOf(",");//"," 문자열의 최초 위치 
              int n2 = sStr.IndexOf(",", n1 + 1);
              int k = n2 - n1 - 1;
              string ss = sStr.Substring(n1+1, k);*/

            string ss = GetToken(sStr, ",", 3);
                MessageBox.Show(ss);
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            int n = int.Parse(comboBox2.Text);
            int m = int.Parse(comboBox2.Items[comboBox2.SelectedIndex].ToString());

            tbTest.Text = GetToken(sStr, ",", n);
            //string s1 = GetToken(sStr, ",", 4);
            //  int n = int.Parse(s1); // comboBox 5번창에 표시된 문자열

            //tbTest.Text = string.Format("{0,10}",n);
            /*  textBox2.Text = string.Format("currency: {0,10:c}", n);
              textBox2.Text = string.Format("decimal: {0,10:d} ", n);
              textBox2.Text = string.Format("scientific: {0,10:e}", n);
              textBox2.Text = string.Format("hexadecimal: {0,10:x}", n);
              textBox2.Text = string.Format("general: {0,10:g}", n);
              textBox2.Text = string.Format(" number: {0,10:n}", n);
              textBox2.Text = string.Format(" percentage: {0,10:p}", n);*/

        }

        private void tbTest_TextChanged(object sender, EventArgs e)
        {
            //16진수
            /*숫자입력시
             int tbt = int.Parse(tbTest.Text);
             textBox2.Text = string.Format("hexadecimal: {0,10:x}", tbt);*/
            string str = tbTest.Text;
            int i, k;
            //int n = tbTest.TextLength;
            int n = str.Length;
            k = int.Parse(textBox3.Text);
            
            StringBuilder sb = new StringBuilder();

            textBox2.Text = "";
            for (i = 0; i < n; i++)
            {

                char a = str[i];
                byte c = (byte)a;
               // textBox2.Text += string.Format(" {0:X2}", c); // 0이 c가 들어가는 자리
               sb.Append($" {c:x2}");
                //Append 와 += 같은 것  계속 문자열 더해주는 것
                if ((i + 1) % k == 0) sb.Append("\r\n");
                //if ((i + 1) % k == 0) textBox2.Text += string.Format(" \r\n"); //  \r\n : 엔터랑 같음************
            
            }
            textBox2.Text = sb.ToString();  
        }
    }
}
