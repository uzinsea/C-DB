using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp2
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(string Section, string key, string def, StringBuilder sb, int size, string path);
        [DllImport("kernel32.dll")]
        private static extern int WritePrivateProfileString(string Section, string key, string val, string path);

        public Form1()
        {
            InitializeComponent();
        }
        // \백슬래시는 이스케이프 문자이기 때문에 경로표시 목적으로 백슬래시를 사용하기 위에서는 앞에 @ 를 붙인다
        //sql DB의 주소는 mdf속성의 연결문자열

        SqlConnection sConn = new SqlConnection();
        SqlCommand sCmd = new SqlCommand();
        string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KOSTA\Source\Repos\Mytable.mdf;Integrated Security=True;Connect Timeout=30";
        // string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\temp;Integrated Security=True;Connect Timeout=30";

        public string GetToken(int n, string str, string sep = ",")
        {
            int i, j, k;
            int n1 = 0, n2 = 0, n3 = 0;
            string sRet;
            for (i = 0, n1 = 0, n2 = 0; i < n; i++)
            {
                n1 = str.IndexOf(sep, n1) + 1;
                if (n1 == 0) return "";
            }
            n2 = str.IndexOf(sep, n1); //n+1 번째 구분자
            if (n2 == -1) n2 = str.Length; //
            n3 = n2 - n1; //문자열 길이 계산
            sRet = str.Substring(n1, n3);
            return sRet;
        }

        string sPath = @".\WinApp2.ini";
        public string GetInI_String(string sec, string key)
        {
            StringBuilder sb = new StringBuilder();
            GetPrivateProfileString(sec, key, "", sb, 500, sPath);
            return sb.ToString();
        }
        public int GetInI_Int(string sec, string key, int def = 0)//함수선언부에서 def=0으로 아예 값설정 가능,그렇지만 추후 수정하면 수정한 대로 값 이용 가능
        {
            StringBuilder sb = new StringBuilder();
            GetPrivateProfileString(sec, key, $"{def}", sb, 500, sPath);

            int nVal = int.Parse(sb.ToString()); //sb를 string으로 바꿔준 다음 다시 int로 파싱

            return nVal;
        }
        private void btnTest11_Click(object sender, EventArgs e)
        {
            //문자열 변환 테스트
            if (rbTest11.Checked == true) label1.Text = tbTest11.Text.ToLower();
            if (rbTest12.Checked == true) label1.Text = tbTest11.Text.ToUpper();
        }
        private void btnTest12_Click(object sender, EventArgs e)
        {
            //텍스트 창에 입련된 문자열을 콤보박스에 추가
            string str = tbTest12.Text;
            int nVal = int.Parse(str);
            cbTest11.Text = str;
            cbTest11.Items.Add(nVal);
            //  string str = tbTest12.Text;
            //  cbTest11.Text = str;
            // cbTest11.Items.Add(str);
        }
        private void cbTest11_SelectedIndexChanged(object sender, EventArgs e)
        {   //콤보박스에 입력된 object 추출 및 변환 텍스트

            //object oVal = cbTest11.SelectedItem;
            //tbTest13.Text = oVal.ToString();
            int nSel = cbTest11.SelectedIndex;
            object oVal = cbTest11.Items[nSel];

            int nVal = (int)oVal; //oVal 을 (int)형식으로 바꾸어 int nVal에 집어넣겠다.
            tbTest13.Text = string.Format("{0} selected", nVal);
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            //tbTest21, tbTest22 영역 재설정
            int w = this.Size.Width; //this는 나 자신 여기서는 form1
            int h = this.Size.Height;

            int sx1 = w / 2 - 60; //tbtest21의 size
            if (sx1 > 50)
            {
                tbTest21.Width = sx1;// tbTest21 가로크기 변경
                tbTest22.Location = new Point(sx1 + 40, tbTest22.Location.Y);
                tbTest22.Width = sx1;
            }

        }
        int cn1, cn2, cn3, cn4, cn5;
        //string sRet;
        private void btnform2_Click(object sender, EventArgs e)
        {
            Form2 dlg = new Form2();
            dlg.comboBox1.SelectedIndex = cn1;
            dlg.comboBox2.SelectedIndex = cn2;
            dlg.comboBox3.SelectedIndex = cn3;
            dlg.comboBox4.SelectedIndex = cn4;
            dlg.comboBox5.SelectedIndex = cn5;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                cn1 = dlg.comboBox1.SelectedIndex;
                cn2 = dlg.comboBox2.SelectedIndex;
                cn3 = dlg.comboBox3.SelectedIndex;
                cn4 = dlg.comboBox4.SelectedIndex;
                cn5 = dlg.comboBox5.SelectedIndex;
                tbTest21.Text = dlg.sRet;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string[] name = { "학생1", "학생2", "학생3" };
            int nsubj = 3; //과목수

            string[] subName = { "C#", "DB", "C++", "IoT", "WEB" };
            int[,] subj = { { 71, 80, 80 },
                                { 80, 43, 71 },
                                { 50, 80, 96 },
                                { 62, 85, 95 },
                                { 75, 81, 85 }
        }; //[,] 이렇게 적으면 2차원 배열

            //nsubj = subj.Length; //subj 전체 요소의 개수=15
            nsubj = subj.GetLength(0); //첫번째 배열의 개수=5과목 두번째 배열의 개수 3
            int m = name.Length; // 배열 요소의 갯수

            int[] total = new int[m];//0으로 초기화 됨
            double[] avg = new double[m];

            string str = "  이름  ";//총 10자리 이름으로 초기화
            for (int j = 0; j < nsubj; j++)
            {
                str += $"{subName[j],5}"; //과목이름
            }
            str += $"    총점    평균\r\n";
            MemoOut(str);

            for (int i = 0; i < m; i++)//인원수 //3
            {
                str = $"{name[i],5} ";
                for (int j = 0; j < nsubj; j++)//과목수
                {
                    total[i] += subj[j, i];
                    str += $"{subj[j, i],5} ";
                }
                //total[i] = subj[0, i] + subj[1, i] + subj[2, i] + subj[3, i] + subj[4, i] + subj[5, i];
                avg[i] = (double)total[i] / nsubj;

                str += $"{ total[i],7} {avg[i],7:F2}\r\n";
                MemoOut(str);
                //tbTest22.Text += str;
            }
        }

        //함수의 일반화 #4
        //함수명 : MemoOut(string str)
        // 인수: string str > 출력할 문자열
        //리턴 : 없음(void)
        //기능: 윈도우 컴포넌트 중 지정된 TextBotx로 출력 문자열을 누적 출력
        //추가기능 : 출력 TextBox 설정 기능
        System.Windows.Forms.TextBox tbOut = null;
        public void MemoOut(string str)
        {
            if (radioButton1.Checked == true)
            {
                tbOut = tbTest21;
                tbOut.Text += str;
            }
            if (radioButton2.Checked == true)
            {
                tbOut = tbTest22;
                tbOut.Text += str;
            }
        }
        private void mnuTbset21_Click(object sender, EventArgs e)
        {
            if (!mnuTbset21.Checked)  //mnuTbtest21를 클릭했는데 체크가 안되어 있을 때!! (체크가 중요)
            {
                tbOut = tbTest21;
                mnuTbset21.Checked = true;
                mnuTbset22.Checked = false;
                radioButton1.Checked = true;
            }
        }
        private void mnuTbset22_Click(object sender, EventArgs e)
        {
            if (!mnuTbset22.Checked)
            {
                tbOut = tbTest22;
                mnuTbset21.Checked = false;
                mnuTbset22.Checked = true;
                radioButton2.Checked = true;


            }
        }
        private void mnuClose_Click(object sender, EventArgs e)
        {
            if (!mnuClose.Checked)
            {
                mnuClose.Checked = true;
                Close();
            }
        }
        private void mnuSelect1_Click(object sender, EventArgs e)
        {
            tbOut = tbTest21;
            radioButton1.Checked = true;
        }

        private void mnuSelect2_Click(object sender, EventArgs e)
        {
            tbOut = tbTest22;
            radioButton2.Checked = true;
        }
        //command 체계:
        // " 컬럼 명칭" : 신규 컬럼 생성
        // " 1,2, 'field_ value'" : 해당 Cell에 field_value 입력 - (1,2)

        private void btnGridCmd_Click(object sender, EventArgs e)
        {//tbGridCmd에 입력된 text로 column 생성
            string str = tbGridCmd.Text;
            try
            {
                if (tbGridCmd.Text != "")
                {
                    if (str.IndexOf(",") == -1) //","의 인덱스가 없을 때는 값이 -1 / ","가 없으면 컬럼 생성
                    {
                        dataGridView1.Columns.Add(str, str); //문자열이 공백이 아니면 입력
                        tbGridCmd.Text = ""; //tbGridCmd.Text 초기화
                    }
                    else
                    {   //1,2 value
                        int col = int.Parse(GetToken(0, str)); //col 에는 1
                        int row = int.Parse(GetToken(1, str));//row에는 2
                        dataGridView1.Rows[row].Cells[col].Value = GetToken(2, str);
                    }
                }
            }

            catch (Exception e1) //에러 났을때, 예외일때
            { }
        }
        private void mnuSelect3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
            //dataGridView1.Rows.Add(5); = 괄호안에 카운트 된 숫자 5행추가
        }
        private void btnExecSql_Click_1(object sender, EventArgs e)
        {
            string sql = tbSql.SelectedText;
            if (sql != "") RunSql(sql);
            else RunSql(tbSql.Text);
            tbSql.Focus();
        }

        private void btnfileopen_Click(object sender, EventArgs e)
        {
            int[] nArr = new int[5]; //여기서 5는 배열의 사이즈, 사이즈를 지정하지않으면 디폴트값은 0이다.

            nArr[0] = 1;
            nArr[1] = 2;
            nArr[2] = 3;
            nArr[3] = 4;

            int[] bArr = { 10, 20, 30 };

            foreach (int n in nArr)
            {
                string str = $"nArr[{n}]={n}\r\n"; //foreach 는 배열의 데이터를 바로 추출한다
                tbTest22.Text += str;
            }

            for (int i = 0; i < 3; i++)
            {
                string str = $"bArr[{i}]={bArr[i]}\r\n";//그냥 for문은 배열[i]로 인덱스를 통해 데이터를 추출한다.
                tbTest22.Text += str;
            }

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fPath = openFileDialog1.FileName;
                FileStream fs = new FileStream(fPath, FileMode.Open);//기존에 존재하는 
                int fSize = (int)fs.Length;
                fs.Close();

                char[] buf = new char[fSize];
                StreamReader sr = new StreamReader(fPath);
                sr.ReadLine(); //1 Line Read : if(EOF) null

                //sr.Read(buf, 0, fSize);
                tbTest21.Text = new string(buf);
                sr.Close();
            }
        }



        private void DBFileSelect_Click(object sender, EventArgs e)
        {
            openFileDialog1.ValidateNames = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fPath = openFileDialog1.FileName;//full path
                string s1 = GetToken(0, connString, ";");//connstring 의 첫번째 필드.
                string s2 = $"AttachDbFilename={fPath}";
                string s3 = GetToken(2, connString, ";");//connstring 의 세번째 필드.
                string s4 = GetToken(3, connString, ";");//connstring 의 네번째 필드.
                connString = s1 + ";" + s2 + ";" + s3 + ";" + s4;
                //$"{s1};{s2};{s3};{s4}"; 같은 결과가 나옴 
                string s5 = openFileDialog1.SafeFileName;
                tbDatabase.Text = s5;
            }
        }
        int DbStatus = 0;

        private void mnuDbupdate_Click(object sender, EventArgs e)
        {

            //int x = dataGridView1.SelectedCells[0].ColumnIndex;
            //int y = dataGridView1.SelectedCells[0].RowIndex; 

            int x = dataGridView1.ColumnCount;
            int y = dataGridView1.RowCount;
            int i, j, k;

            for (i = 0; i < y; i++) // Row index
            {
                for (j = 0; j < x; j++)  // Column index
                {
                    if (dataGridView1.Rows[i].Cells[j].ToolTipText == ".")
                    {
                        string s1 = dataGridView1.Columns[j].HeaderText;    // field 명
                        string s2 = dataGridView1.Rows[i].Cells[j].Value.ToString(); // 수정된 데이터
                        string s3 = (string)dataGridView1.Rows[i].Cells[0].Value;    // id 번호
                        string s4 = $"update {cbTable.Text} set {s1}='{s2}' where id={s3}";
                        RunSql(s4);

                        dataGridView1.Rows[i].Cells[j].ToolTipText = "";
                    }
                }
            }


            //sCmd.CommandText = s4; //s4문장을 커맨드 텍스트에 넣어주기
            //sCmd.ExecuteNonQuery();//리턴이 없는 update문 실행 
        }
        //함수 일반화 #5
        //함수명 : RunSql(string sql)
        //인수: stirng sql: 실행할 SQL문
        // 리턴: -1 오류 1 or 0 정상
        // 기능: SQL문을 sCmd 오브젝트를 이용하여 수행하고
        //결과값이 있을 경우 (Select) Grid에 표현해주고 
        //하단의 statusBar에 수행 결과를 표시

        public int RunSql(string sSql)
        {
            try
            {
                //               sSql = tbSql.Text;
                sCmd.CommandText = sSql;
                int i, j, k;

                string s1 = GetToken(0, sSql, " ").ToUpper(); // "SELECT FCODE, FNAME FROM FACILITY
                if (s1 != "SELECT")
                    sCmd.ExecuteNonQuery();//return 값이 없는 쿼리문 ex) insert/update/delete
                else //쿼리문이 select일 때
                {

                    SqlDataReader sr = sCmd.ExecuteReader();
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();


                    for (i = 0; i < sr.FieldCount; i++)//결국 fieldcount가 없을 때 라는 이야기 
                    {
                        dataGridView1.Columns.Add(sr.GetName(i), sr.GetName(i));//맨 첫 행에 각 열의 이름을 담는다.
                    }

                    for (i = 0; sr.Read(); i++)//처리할 데이터가 있으면 1라인씩 처리 //row //sr.Read() 는 boolean 
                    {
                        if (dataGridView1.RowCount < i + 2) dataGridView1.Rows.Add();//열보다 행이 적을 때 추가 
                        for (j = 0; j < sr.FieldCount; j++) //filedcount = column?
                        {
                            object o2 = sr.GetValue(j);
                            string buf = $"{o2}";
                            dataGridView1.Rows[i].Cells[j].Value = buf;
                            //dataGridView1.Rows[i].Cells[j].Value = $"{sr.GetValue(j)}";
                        }
                    }
                    sr.Close();
                }
                Statuslabel2.BackColor = Color.Violet;
                Statuslabel2.Text = "success";
            }
            catch (Exception e1)
            {
                Statuslabel2.BackColor = Color.Red;
                Statuslabel2.Text = "fail";
                StatusLabel3.Text = e1.Message;
            }
            return 0;
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {   // Kbd 입력이 발생했을 때
            int x = dataGridView1.SelectedCells[0].ColumnIndex;
            int y = dataGridView1.SelectedCells[0].RowIndex;

            //만일 편집 중인 셀이 신규 생성된 Row이면(.) insert 준비 ( .. )
            if (dataGridView1.Rows[y].HeaderCell.Value.ToString() == ".")
                dataGridView1.Rows[y].HeaderCell.Value = "..";
                dataGridView1.SelectedCells[0].ToolTipText = ".";
        }

        private void cbTable_SelectedIndexChanged(object sender, EventArgs e)
        {

            string str = $"select * from {cbTable.SelectedItem.ToString()}";
            RunSql(str);



        }

        private void mnuDbClose_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            tbDatabase.Clear();
            cbTable.Text = "";
            cbTable.Items.Clear();
            StatusLabel1.Text = "DB closed";
            sConn.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void mnuxls_Click(object sender, EventArgs e)
        {
            try
            {
                //string connString2 = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\temp;Integrated Security=True;Connect Timeout=30";
                openFileDialog1.ValidateNames = false;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string fPath = openFileDialog1.FileName;

                    StreamReader sr = new StreamReader(fPath);
                    //sr.read(buf) : buf size만큼의 데이터를 한번에 Read
                    string str;
                    int i, j, k;

                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    int nCol = 0;
                    //datagrid에 헤더컬럼 추가

                    str = sr.ReadLine(); //Haeder Line: dataGrid에 헤더컬럼 추가
                    for (i = 0; ; i++)
                    {
                        string c1 = GetToken(i, str);
                        if (c1 == "") { nCol = i; break; }
                        dataGridView1.Columns.Add(c1, c1);

                    }
                    for (i = 0; ; i++)//한바퀴 돌때마다 str에 한 라인씩 담기게 됨 for루프가 끝나는 순간 str는 날아감
                    {
                        str = sr.ReadLine();
                        if (str == null) break;
                        dataGridView1.Rows.Add();
                        for (j = 0; j < nCol; j++)
                        {
                            string c1 = GetToken(j, str);
                            dataGridView1.Rows[i].Cells[j].Value = c1;
                        }
                    }
                    Statuslabel2.BackColor = Color.Blue;
                    Statuslabel2.Text = "success";
                    sr.Close();
                }
            }
            catch (Exception e1)
            {
                Statuslabel2.BackColor = Color.Red;
                Statuslabel2.Text = "fail";
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        //0.DB파일(.mdf)은 현재 OPEN 되어 있는 DB 사용
        //1. 입력창을 열어서 신규 Table 이름 입력 = frmGettable
        //2. 현재 Grid의 헤더컬럼을 필드이름으로 하는 Table을 creation
        //3. 현재 Grid의 각 cell의 data를 DB에 INSERT
        private void mnuDBsave_Click(object sender, EventArgs e)
        {
            //1. 입력창을 열어서 신규 Table 이름 입력 = frmGettable
            frmGettable dlg = new frmGettable();
            dlg.ShowDialog();
            string sName = dlg.tbTablename.Text;

            //2. 현재 Grid의 헤더컬럼을 필드이름으로 하는 Table을 creation
            //create table[테이블명]( [필드명: column명][필드속성:nchar(20))
            //-->>sql 실행

            int nCol = dataGridView1.Columns.Count;
            int nRow = dataGridView1.Rows.Count;
            string sCreate = $"CREATE TABLE {sName} (";

            for (int i = 0; i < nCol; i++)
            {
                string c1 = dataGridView1.Columns[i].HeaderText;
                sCreate += $"{c1} nchar(20)"; // 열의 수 만큼 누적으로 필드명과 필드 속성이 작성된다
                if (i < nCol - 1) sCreate += ",";//마지막 칼럼이 아닌 경우 컴마 붙여주기
            }
            sCreate += ")";
            // RunSql(sCreate);
            string sInsert = $" INSERT INTO {sName} VALUES";

            for (int j = 0; j < nRow; j++) // Row index
            {
                sInsert += "(";
                for (int k = 0; k < nCol; k++)
                {
                    string c2 = (string)dataGridView1.Rows[j].Cells[k].Value;
                    sInsert += $"'{c2}'";
                    if (k < nCol - 1) sInsert += ",";
                }
                sInsert += ")";
                if (j < nRow - 1) sInsert += ",";
            }
            //RunSql(sInsert);

            sCreate += sInsert;
            RunSql(sCreate);
            cbTable.Items.Add(sName);
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tbDatabase_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        int Dbstatus = 0;
        //함수명 GetDbTableNames()
        //인수없음:
        //return 없음
        // 기능: 현재 open 되어 있는 DB의 Table 명을 cbTable 콤보박스에 넣는다
        public void GetDbTableNames()
        {
            DataTable dt = sConn.GetSchema("Tables"); //getschema = db구조
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string sTablename = dt.Rows[i].ItemArray[2].ToString(); //itemarray는 object
                cbTable.Items.Add(sTablename);
            }
        }

        private void mnuDeleteTable_Click(object sender, EventArgs e)
        {
            if (cbTable.Text != "")
            {
                RunSql($"DROP TABLE {cbTable.Text}");
                Statuslabel2.Text = $"table {cbTable.Text} dropped!";
                GetDbTableNames();
                return;
            }
            else Statuslabel2.Text = $"테이블 삭제 실패";

        }
        //함수명 : InsertRow(int n)
        //인수 : n - insert할 row의 index
        // 리턴 값 : 없음
        // 기능 : 지정된 row의 모든 셀을 table에 insert
        public void insertRow(int n)
        {
            int nCol = dataGridView1.Columns.Count;
            int nRow = dataGridView1.Rows.Count;
            string sName = cbTable.Text;
            string sInsert = $"INSERT INTO {cbTable.Text} VALUES";
            string c1 = "(";
            for (int j = 0; j<nCol; j++)
            {
                string c2 = dataGridView1.Rows[n].Cells[j].Value.ToString();
                c1 += $"'{c2}'";
                if (j < nCol - 1) c1 += ",";
            }
            c1 += ")";
            sInsert += c1;
            RunSql(sInsert);
        }
       

        private void mnuDbInsert_Click(object sender, EventArgs e)
        {
            int nCol = dataGridView1.Columns.Count;
            int nRow = dataGridView1.Rows.Count;
            string sInsert = $"INSERT INTO {cbTable.Text} VALUES";
            //INSERT into [TABLE] values (
            for (int j = 0; j < nRow-1; j++)
            {
                sInsert += " (";
                for(int k = 0; k < nCol; k++)
                {
                    string c1 = (string)dataGridView1.Rows[j].Cells[k].Value;
                    sInsert += $"'{c1}'";
                    if (k < nCol - 1) sInsert += ",";
                }
                sInsert += ")";
                if (j < nRow - 2) sInsert += ",";
            }
            RunSql(sInsert);
            Statuslabel2.Text = "insert sucess";
        }
    
        private void mnuDbDelete_Click(object sender, EventArgs e)
        {
            //gridview에 있는 table의 해당 record 삭제
            //현재 Grid에 있는 데이터가 id필드를 포함한 경우에만 동작
            string sHdr = dataGridView1.Columns[0].HeaderText.ToLower();
            if(sHdr == "id")
            {   //selectedcells[0] <내가 선택한 셀
                int x = dataGridView1.SelectedCells[0].ColumnIndex; //선택한 셀의 열인덱스
                int y = dataGridView1.SelectedCells[0].RowIndex;//선택한 셀의 행인덱스
                string sId = dataGridView1.Rows[0].Cells[0].Value.ToString();
                string sTbl = cbTable.Text;

                RunSql($"DELETE {sTbl} where id={sId}");
                Statuslabel2.Text = "delete sucess";
                return;
            }
            Statuslabel2.Text = "delete fail";
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //DataGrid의 Row가 새로 생성되었을 때
            int nRow = e.RowIndex;
            dataGridView1.Rows[nRow].HeaderCell.Value = "."; //신규 row flag
        }
        public string RunDBData(string keyname, string table_name)
        {
            string sql = $"select svalue from {table_name} where sKey='{keyname}'";
            sCmd.CommandText = sql;

            string sRet = sCmd.ExecuteScalar().ToString();// select문 처리결과 수신
            return sRet;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string str = RunDBData(textBox1.Text, "Myconfig");
            tbSql.Text += $" Myconfig test [{textBox1.Text}] : '{str}'\r\n";

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbSql_TextChanged(object sender, EventArgs e)
        {

        }

        private void mnuDBOpen_Click(object sender, EventArgs e)
        {
            try
            {
                sConn.ConnectionString = connString;
                sConn.Open();
                sCmd.Connection = sConn;

                GetDbTableNames();

                StatusLabel1.BackColor = Color.Green;
                StatusLabel1.Text = "DB opened success";
                DbStatus = 1;
            }
            catch (Exception e1)
            {
                StatusLabel1.BackColor = Color.Red;
                StatusLabel1.Text = "DB opened fail";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] name = { "학생1", "학생2", "학생3" };

            int nsubj = 3; //과목수
            int[] subj1 = { 71, 80, 80 };
            int[] subj2 = { 80, 43, 71 };
            int[] subj3 = { 50, 80, 96 };
            int[] subj4 = { 75, 85, 95 };



            int[] total = new int[3];
            double[] avg = new double[3];

            int m = name.Length; // 배열 요소의 갯수

            tbTest22.Text += "이름    C#   DB    HTML   Total   Average\r\n";
            tbTest22.Text += "=======================================\r\n";

            for (int i = 0; i < m; i++)
            {

                total[i] = subj1[i] + subj2[i] + subj3[i];
                avg[i] = (double)total[i] / nsubj;//avg는 double(실수)이지만 total과 n은 int(정수)라서 avg가 82.33인데도 82.00으로 나옴
                string str = $"{name[i],2}{subj1[i],5}{subj2[i],7}{subj3[i],7}{total[i],10}{avg[i],12:F2}\r\n";//12:F2의 F2 2개의 소수점(F)자리,12는 avg[i]가 차지하는 자리 크기
                tbTest22.Text += str;

            }
            //for (int i = 0; i < 3; i++)
            //{
            //    total[i] = c[i] + db[i] + html[i];
            //    avg[i] = total[i] / n;

            //    string str = $"{name[i]}   {c[i]}   {db[i]}     {html[i]}        {total[i]}         {avg[i]}\r\n";
            //    tbTest22.Text += str;
            //    //string name = nameArr[i];
            //    //int total = cArr[i] + dbArr[i] + htmlArr[i];
            //    //int avg = total / 3;
            //    //string str = $"\r\nname = {name},total = {total},avg = {avg}\r\n";
            //    //tbTest22.Text += str;

            //}
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            Form1_Resize(sender, e);
            cn1 = GetInI_Int("Form2 Combo Set", "cn1");
            cn2 = GetInI_Int("Form2 Combo Set", "cn2");
            cn3 = GetInI_Int("Form2 Combo Set", "cn3");
            cn4 = GetInI_Int("Form2 Combo Set", "cn4");
            cn5 = GetInI_Int("Form2 Combo Set", "cn5");
            tabControl1.SelectedIndex = GetInI_Int("Window config", "tapPage");

            tbTest21.Text = GetInI_String("tbTest21 set", "sRet");

            this.Width = GetInI_Int("form1 Size Set", "Width", 780);
            this.Height = GetInI_Int("form1 Size Set", "Height", 520);
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DbStatus == 1) sConn.Close();
            WritePrivateProfileString("Form2 Combo Set", "cn1", string.Format("{0}", cn1), sPath);
            WritePrivateProfileString("Form2 Combo Set", "cn2", string.Format("{0}", cn2), sPath);
            WritePrivateProfileString("Form2 Combo Set", "cn3", string.Format("{0}", cn3), sPath);
            WritePrivateProfileString("Form2 Combo Set", "cn4", string.Format("{0}", cn4), sPath);
            WritePrivateProfileString("Form2 Combo Set", "cn5", string.Format("{0}", cn5), sPath);
            WritePrivateProfileString("Window config", "tapPage", $"{tabControl1.SelectedIndex}", sPath);
            //WritePrivateProfileString("tbTest21 set", "sRet", tbTest21.Text, sPath);
            WritePrivateProfileString("form1 Size Set", "Width", $"{this.Width}", sPath);
            WritePrivateProfileString("form1 Size Set", "Height", $"{this.Height}", sPath);

        }


    }
}

