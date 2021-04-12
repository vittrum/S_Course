using System;
using System.Windows.Forms;

namespace Sofa_Course
{
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            Init();
        }
        private void Init() {
            // student
            FillDgvStudentRequests(dgvStudentRequest);
            requester.ShowStudentsRequest(factory, dgvStudentRequest, _id);
            // caretaker
            FillDgvStudentsShort(dgvCareStudents);
            requester.ShowStudents(factory, dgvCareStudents);
            FillDgvLinens(dgvCareLinens);
            requester.GetLinens(factory, dgvCareLinens);
            requester.GetFreeLinens(factory, comboLinens);
            // admin
            FillDgvStudentsShort(dgvAdminStudents);
            requester.ShowStudents(factory, dgvAdminStudents);
            FillDgvViolations(dgvViolations);
            requester.GetViolations(factory, dgvViolations);

            // watchman
            // violations
            FillDgvStudentsShort(dgvReports);
            requester.ShowStudents(factory, dgvReports);
            // staff
        }
        Requester requester = new Requester();
        Factory factory = new Factory("127.0.0.1", "5432", "postgres", "1", "dormitory");
        string _id = "1";

        #region Student
        private void BtnShowStudents_Click(object sender, EventArgs e) {
            FillDgvStudentsShort(dgvShowStudents);
            string course = ComboStudCourse.Text;
            string specialty = ComboStudSpec.Text;
            requester.ShowLivingStudents(factory, dgvShowStudents, course, specialty);
        }
        private void BtnCreateRequestStudent_Click(object sender, EventArgs e) {
            requester.CreateRepairRequest(factory, _id, tbTypeOfRepair.Text, "поломка");
            FillDgvStudentRequests(dgvStudentRequest);
            requester.ShowStudentsRequest(factory, dgvStudentRequest, _id);
        }
        private void BtnConfirmStudent_Click(object sender, EventArgs e) {
            string repair_id = dgvStudentRequest.SelectedRows[0].Cells[0].Value.ToString();
            if (repair_id != "")
            {
                requester.ConfirmRepairs(factory, repair_id);
                FillDgvStudentRequests(dgvStudentRequest);
                requester.ShowStudentsRequest(factory, dgvStudentRequest, _id);
            }            
        }
        #endregion

        #region DgvFill

        // Для студентов, завхоза, вахтёра, заведующего
        public void FillDgvStudentsShort(DataGridView dgv) {
            dgv.Columns.Clear();
            dgv.Columns.Add("id", "Номер");
            dgv.Columns.Add("name", "Имя");
            dgv.Columns.Add("lastname", "Фамилия");
            dgv.Columns.Add("patr", "Отчество");
            dgv.Columns.Add("fac", "Факультет");
            dgv.Columns.Add("spec", "Курс");
        }
        // Для Техперсонала
        public void FillDgvStaffRequests(DataGridView dgv) {
            dgv.Columns.Clear();
            dgv.Columns.Add("id_req", "Номер заявки");
            dgv.Columns.Add("id_room", "Номер комнаты");
            dgv.Columns.Add("type", "Тип");
            dgv.Columns.Add("theme", "Тема");
            dgv.Columns.Add("date_b", "Дата подачи");
            dgv.Columns.Add("date_e", "Дата выполнения");
        }
        // Для студентов
        public void FillDgvStudentRequests(DataGridView dgv) {
            dgv.Columns.Clear();
            dgv.Columns.Add("id_req", "Номер заявки");
            dgv.Columns.Add("type", "Тип");
            dgv.Columns.Add("theme", "Тема");
            dgv.Columns.Add("date_b", "Дата подачи");
        }
        // Для завхоза
        public void FillDgvLinens(DataGridView dgv)
        {
            dgv.Columns.Clear();
            dgv.Columns.Add("id_lin", "Номер белья");
            dgv.Columns.Add("id_stud", "Номер билета");
            dgv.Columns.Add("grant_date", "Дата выдачи");
            dgv.Columns.Add("revoke_date", "Дата приема");
        }
        // Для списка нарушений
        public void FillDgvViolations(DataGridView dgv)
        {
            dgv.Columns.Clear();
            dgv.Columns.Add("id", "Номер нарушения");
            dgv.Columns.Add("date", "Дата");
            dgv.Columns.Add("type", "Тип");
            dgv.Columns.Add("penalty", "Наказание");
        }
   
        #endregion

        // Техперсонал
        private void BtnStaffRefresh_Click(object sender, EventArgs e) {
            FillDgvStaffRequests(dgvStaffShowRequests);
            requester.ShowRepairRequests(factory, dgvStaffShowRequests);
        }
        // Завхоз
        private void BtnGuveLinens_Click(object sender, EventArgs e) {
            string linens_id = comboLinens.Text.ToString();
            if (linens_id != "")
            {
                string student_id = dgvCareStudents.SelectedRows[0].Cells[0].Value.ToString();
                requester.GiveLinens(factory, student_id, linens_id);
                FillDgvLinens(dgvCareLinens);
                requester.GetLinens(factory, dgvCareLinens);
                comboLinens.Items.Clear();
                requester.GetFreeLinens(factory, comboLinens);
            }
            else
            {
                MessageBox.Show("No linens chosen!");
            }
        }

        private void BtnGetLinens_Click(object sender, EventArgs e) {
            foreach (DataGridViewRow row in dgvCareLinens.SelectedRows)
            {
                requester.ReturnLinens(factory, row.Cells["id_lin"].Value.ToString());
            }                
            FillDgvLinens(dgvCareLinens);
            requester.GetLinens(factory, dgvCareLinens);
            comboLinens.Items.Clear();
            requester.GetFreeLinens(factory,comboLinens);
        }
        // Вахтёр
        private void BtnPassStudent_Click(object sender, EventArgs e) {
            FillDgvStudentsShort(dgvWatchFind);
            string name = tbWatchStudName.Text;
            string lastname = tbWatchStudLast.Text;
            requester.PassStudent(factory, dgvWatchFind, name, lastname);
        }

        private void BtnPassGuest_Click(object sender, EventArgs e) {
            try
            {
                string student_id = dgvWatchFind.SelectedRows[0].Cells[0].Value.ToString();
                requester.PassGuest(factory, tbGuestName.Text, tbGuestSurname.Text,
                    tbGuestPatr.Text, tbGuestHome.Text, Convert.ToInt32(student_id));
            }
            catch { MessageBox.Show("Select related student!"); }
        }

        private void BtnShowGuests_Click(object sender, EventArgs e) {
           /* FillDgvWatchGuests();
            requester.Show_Guests(factory, dgvWatchGuests);*/
        }
        #region Zaveduyuschii
        private void BtnSettle_Click(object sender, EventArgs e) {
            string name = tbZavName.Text;
            string last = tbZavSurname.Text;
            string father = tbZavPatr.Text;
            int course = Convert.ToInt32(numZavCourse.Value);
            string spec = tbZavSpec.Text;
            string paycheck = tbPaycheck.Text;
            string sanpass = dateSani.Value.ToShortDateString();
            int roomnum = Convert.ToInt32(comboZavRoom.Text);
            int priv = Convert.ToInt32(comboPrivName.Text);
            requester.SettleStudent(factory, name, last, father, course,
                spec, paycheck, sanpass, priv, roomnum);
        }
        private void BtnSetPen_Click(object sender, EventArgs e) {
           // requester.Set_Penalty(factory, comboOtrabotki.SelectedItem.ToString(), tbSetPen.Text);
        }
        private void BtnKick_Click(object sender, EventArgs e) {
            int student_id = Convert.ToInt32(dgvAdminStudents.SelectedRows[0].Cells[0].Value);
            requester.KickStudent(factory, student_id);
        }

        #endregion
        // Заявка о нарушении
        private void BtnSendReport_Click(object sender, EventArgs e) {
            string student_id = dgvReports.SelectedRows[0].Cells[0].Value.ToString();
            string text = tbTextReport.Text;
            string fact = tbFactViolation.Text;
            FillDgvStudentsShort(dgvViolations);
            requester.ShowStudents(factory, dgvViolations);
            requester.CreateViolation(factory, student_id, text, fact);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = tbLogin.Text;
            string password = tbPass.Text;
            string role = "";
            bool success = true;
            try
            {
                factory = new Factory("127.0.0.1", "5432", login, password, "dormitory");
                role = requester.CheckRole(factory, login);
            }
            catch (Exception ex)
            {
                success = false;
                MessageBox.Show("Проверьте соединение и корректность введенных данных" + ex.Message);
            }
            if (success)
            {
                tabCon.Visible = true;                
                if (role == "student")
                {
                    _id = requester.GetId(factory, role, login);
                    tabStaff.Dispose();
                    tabSupMan.Dispose();
                    tabWatchman.Dispose();
                    tabDirector.Dispose();
                }
                else if (role == "caretaker")
                {
                    tabStudent.Dispose();
                    tabStaff.Dispose();
                    tabWatchman.Dispose();
                    tabDirector.Dispose();
                }
                else if (role == "tech")
                {
                    tabStudent.Dispose();
                    tabStaff.Dispose();
                    tabSupMan.Dispose();
                    tabDirector.Dispose();
                }
                else if (role == "watchman")
                {
                    tabStudent.Dispose();
                    tabStaff.Dispose();
                    tabSupMan.Dispose();
                    tabDirector.Dispose();
                }
                else if (role == "admin")
                {
                    tabStudent.Dispose();
                    tabStaff.Dispose();
                    tabSupMan.Dispose();
                    tabWatchman.Dispose();
                }
            }
        }
    }
}
