using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bsy201601587
{
    public partial class bsy201601587 : Form
    {
        GroupBox[] GB = new GroupBox[3]; // 그룹 박스 
        RadioButton[,] Bogi = new RadioButton[3, 5];  // 보기 
        Label[] Quiz = new Label[3];            //문제
        Label lbScore = new Label();     // 점수 표시 Label  
        Button button = new Button();  // Button 
        PictureBox pbBaby = new PictureBox();   // 아기 사진
        int Score = 0;                          // 점수 변수

        Random rand = new Random();
        int[] qnum = new int[5];
        int[] bnum = new int[5];

        string aa = "[문제 ";
        string[,] Question = new string[5, 6] {
            { "다음 중 1 + 1 = ?" , "일", "이", "삼", "사", "이"},
            { "인천에 있는 산은 ?", "한라산", "백두산", "계양산", "금강산", "계양산"},
            { "인천 대학은 어느 구에 있나 ?", "송도구", "연수구", "남구", "중구", "연수구" },
            { "다음 중 게임 속 캐릭터가 아닌 것은 ?", "샌즈.png", "아이작.png", "투더문.jpg", "너굴맨.jpg", "너굴맨.jpg" },
            { "이 아이의 이름은 ?", "윌리엄 해밍턴", "샘 해밍턴", "샘 오취리", "샘 윌리엄", "윌리엄 해밍턴" } };

        public bsy201601587()
        {
            InitializeComponent();
            this.AutoSize = true;
            #region
            for (int i = 0; i < 5; i++)
            {
                int rnum = rand.Next(0, 5);
                if (i == 0)
                {
                    qnum[i] = rnum;
                    continue;
                }

                for (int j = 0; j < i; j++)
                {
                    if (qnum[j] == rnum)
                    {
                        rnum = rand.Next(0, 5);
                        j = -1;
                    }
                }
                qnum[i] = rnum;
            }
            #endregion

            #region
            for (int i = 0; i < 5; i++)
            {
                int rnum = rand.Next(1, 5);
                if (i == 4)
                {
                    bnum[i] = 5;
                    break;
                }

                for (int j = 0; j < i; j++)
                {
                    if (bnum[j] == rnum)
                    {
                        rnum = rand.Next(1, 5);
                        j = -1;
                    }
                }
                bnum[i] = rnum;
            }
            #endregion

            #region
            lbScore = new Label();
            this.lbScore.Name = "lblScore";
            this.lbScore.Text = "Score : ";
            this.lbScore.Size = new Size(90, 30);
            this.lbScore.AutoSize = true;
            this.lbScore.Location = new System.Drawing.Point(30, 630);
            this.Controls.Add(lbScore);
            #endregion

            #region
            this.button.Name = "btnSubmit";
            this.button.Text = "채점하기";
            this.button.Size = new Size(90, 30);
            this.button.AutoSize = true;
            this.button.Location = new System.Drawing.Point(150, 630);
            this.button.Click += new EventHandler(button_Click);
            this.Controls.Add(button);
            #endregion

            #region
            int l = 10;
            for (int n = 0; n < GB.Length; n++)
            {
                GB[n] = new GroupBox();
                this.GB[n].AutoSize = true;
                this.GB[n].TabIndex = 0;
                this.GB[n].TabStop = false;
                this.GB[n].Text = aa + (n + 1) + "] " + Question[qnum[n], 0];
                this.GB[n].Location = new System.Drawing.Point(10, l);
                if (qnum[n] == 3)
                {
                    this.GB[n].Size = new System.Drawing.Size(350, 280);
                    this.Controls.Add(GB[n]);

                    for (int i = 0; i < 5; i++)
                    {
                        Bogi[n, i] = new RadioButton();
                        this.Bogi[n, i].Size = new System.Drawing.Size(100, 100);
                        if (i < 2)
                            this.Bogi[n, i].Location = new System.Drawing.Point(30 + (i * 170), 30);
                        else
                            this.Bogi[n, i].Location = new System.Drawing.Point(30 + ((i - 2) * 170), 150);
                        if (i == 4) Bogi[n, i].Visible = false;
                        this.Bogi[n, i].Image = Image.FromFile(Question[qnum[n], bnum[i]]);
                        this.Bogi[n, i].Name = Question[qnum[n], bnum[i]];
                        this.Controls.Add(Bogi[n, i]);
                        this.GB[n].Controls.Add(this.Bogi[n, i]);
                    }
                    l += 310;
                    continue;
                }
                else if (qnum[n] == 4)
                {
                    this.GB[n].Size = new System.Drawing.Size(350, 210);
                    this.Controls.Add(GB[n]);
                    this.pbBaby.Location = new System.Drawing.Point(20, 35);
                    this.pbBaby.Size = new System.Drawing.Size(150, 150);
                    this.pbBaby.Image = Image.FromFile("윌리엄해밍턴.jpg");
                    this.Controls.Add(pbBaby);
                    this.GB[n].Controls.Add(this.pbBaby);
                    for (int i = 0; i < 5; i++)
                    {
                        Bogi[n, i] = new RadioButton();
                        this.Bogi[n, i].Location = new System.Drawing.Point(190, 40 + (i * 40));
                        this.Bogi[n, i].Size = new System.Drawing.Size(100, 20);
                        this.Bogi[n, i].Text = Question[qnum[n], bnum[i]];
                        if (i == 4)
                            Bogi[n, 4].Visible = false;
                        this.Bogi[n, i].Name = Question[qnum[n], bnum[i]];
                        this.Controls.Add(Bogi[n, i]);
                        this.GB[n].Controls.Add(this.Bogi[n, i]);
                    }
                    l += 220;
                    continue;
                }
                this.GB[n].Size = new System.Drawing.Size(350, 80);
                this.Controls.Add(GB[n]);

                for (int i = 0; i < 5; i++)
                {
                    Bogi[n, i] = new RadioButton();
                    this.Bogi[n, i].Location = new System.Drawing.Point(30 + (i * 80), 30);
                    this.Bogi[n, i].Size = new System.Drawing.Size(70, 20);
                    this.Bogi[n, i].Text = Question[qnum[n], bnum[i]];
                    if (i == 4)
                        Bogi[n, 4].Visible = false;
                    this.Bogi[n, i].Name = Question[qnum[n], bnum[i]];
                    this.Controls.Add(Bogi[n, i]);
                    this.GB[n].Controls.Add(this.Bogi[n, i]);
                }
                l += 90;
            }
            #endregion
        }

        void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Score = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Bogi[i, j].Name == Question[qnum[i], 5]
                        && Bogi[i, j].Checked == true)
                        Score++;
                }
            }
            lbScore.Text = "Score : " + Convert.ToString(Score);
        }
    }
}
