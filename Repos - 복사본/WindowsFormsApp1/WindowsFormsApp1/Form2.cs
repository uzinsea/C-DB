using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        //전역변수는 컴파일러에 의해 초기화
        public string as1, as2, as3, as4, as5; //public : class 외부에서 참조 가능

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e) //form2가 form1에서 load 될 떄 바로 초기값 생성되어야 함 
        {
            comboBox1.SelectedIndex = cn1;
            comboBox2.SelectedIndex = cn2;
            comboBox3.SelectedIndex = cn3;
            comboBox4.SelectedIndex = cn4;
            comboBox5.SelectedIndex = cn5;
        }

        public int cn1, cn2, cn3, cn4, cn5; //cn = combobox selected index ->콤보박스의 현재 선택값 보관용 
        public Form2()  //Creator
        {
            InitializeComponent();
            //지역변수는 컴파일러에 의해 초기화 되지 않음
            /*comboBox1.SelectedIndex = cn1;
            comboBox2.SelectedIndex = cn2;
            comboBox3.SelectedIndex = cn3;
            comboBox4.SelectedIndex = cn4;
            comboBox5.SelectedIndex = cn5;*/ // 여기다가 이걸 넣어놓으면 form1이 다 실행된 후 다시 form2로 돌아가기 때문에 form1 내용이 form2에 저장되지 않은채로 초기값 재설정
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            as1 = comboBox1.Text;
            as2 = comboBox2.Text;
            as3 = comboBox3.Text;
            as4 = comboBox4.Text;
            as5 = comboBox5.Text;

            cn1 = comboBox1.SelectedIndex;
            cn2 = comboBox2.SelectedIndex;
            cn3 = comboBox3.SelectedIndex;
            cn4 = comboBox4.SelectedIndex;
            cn5 = comboBox5.SelectedIndex;

            //int a = int.Parse(as5); //parse: 문자를 숫자로 변환해준다 
            //double a1 = double.Parse(as5);

        }
    }
}
