using Caliburn.Micro;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ThirdCaliburnApp.Models;

namespace ThirdCaliburnApp.ViewModels
{
    public class MainViewModel : Conductor<object>, IHaveDisplayName
    {

        #region 속성 영역
        EmployeesModel employeesModel;

        int id;
        public int Id
        { 
            get=>id; 
            set 
            { 
                id = value;
                NotifyOfPropertyChange(() => id);
            }
        }

        string empName;
        public string EmpName 
        { 
            get=>empName; 
            set 
            { 
                empName = value; 
                NotifyOfPropertyChange(() => EmpName); 
            } 
        }

        decimal salary;
        public decimal Salary 
        { 
            get=>salary; 
            set 
            { 
                salary = value; 
                NotifyOfPropertyChange(() => Salary); 
            } 
        }

        string deptName;
        public string DeptName 
        { 
            get=>deptName; 
            set 
            { 
                deptName = value;
                NotifyOfPropertyChange(() => DeptName);
            } 
        }

        string destination;
        public string Destination 
        { 
            get=>destination; 
            set 
            { 
                destination = value; 
                NotifyOfPropertyChange(() => Destination); 
            } 
        }

        //전체 Employees 리스트
        BindableCollection<EmployeesModel> employees;
        public BindableCollection<EmployeesModel> Employees 
        {
            get => employees;
            set
            {
                employees = value;
                NotifyOfPropertyChange(() => Employees);
            }
        }

        //Employees 리스트 중 선택된 하나 Employee
        EmployeesModel selectedEmployee;
        public EmployeesModel SelectedEmployee //모델 하나 선택할 때 SelectedEmployee는 Employees중 한개!
        {
            get=>selectedEmployee;
            set
            {
                //왼쪽 클릭시 오른쪽으로 데이터 넘어오는 다리역할
                selectedEmployee = value;
                Id = value.Id;
                EmpName = value.EmpName;
                Salary = value.Salary;
                DeptName = value.DeptName;
                Destination = value.Destination;

                NotifyOfPropertyChange(() => SelectedEmployee);
                NotifyOfPropertyChange(() => Id);
            }
        }

        #endregion

        #region 생성자 영역
        public MainViewModel()
        {
            GetEmployees();
        }
        #endregion

        public void NewEmployee()
        {
            //db와 관련 x, clear기능
            Id = 0;
            EmpName = string.Empty;
            Salary = 0;
            DeptName = Destination = string.Empty;
        }


        private void GetEmployees()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(EmployeesTbl.SELECT_EMPLOYEES, conn);
                //cmd.Connection = conn;이렇게하거나 (strQuery, conn)<- conn하거나 둘 중 하나

                MySqlDataReader reader = cmd.ExecuteReader();
                Employees = new BindableCollection<EmployeesModel>();

                while (reader.Read())
                {
                    var temp = new EmployeesModel
                    {
                        //생성자
                        Id = (int)reader["id"], //[id] <- mysql데이터
                        EmpName = reader["EmpName"].ToString(),
                        Salary = (decimal)reader["Salary"],
                        DeptName = reader["DeptName"].ToString(),
                        Destination =  reader["Destination"].ToString()//(int),.ToString() : 형변환
                    };
                    Employees.Add(temp);
                }
            }
        }

        public bool CanSaveEmployee
        {
            get
            {
                return !((Id == 0) && string.IsNullOrEmpty(EmpName) && (Salary == 0) && string.IsNullOrEmpty(DeptName) && string.IsNullOrEmpty(Destination));
                //return 값이 없으면 false(<- 저장버튼비활성화), 값 있으면 true
            }
        }

        public void SaveEmployee()
        {
            int resultRow = 0;
            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(EmployeesTbl.UPDATE_EMPLOYEE, conn);
                MySqlParameter paramEmpName = new MySqlParameter("@EmpName", MySqlDbType.VarChar, 45);
                paramEmpName.Value = EmpName;
                cmd.Parameters.Add(paramEmpName);

                MySqlParameter paramSalary = new MySqlParameter("@Salary", MySqlDbType.Decimal);
                paramSalary.Value = Salary;
                cmd.Parameters.Add(paramSalary);

                MySqlParameter paramDeptName = new MySqlParameter("@DeptName", MySqlDbType.VarChar, 45);
                paramDeptName.Value = DeptName;
                cmd.Parameters.Add(paramDeptName);

                MySqlParameter paramDestination = new MySqlParameter("@Destination", MySqlDbType.VarChar, 45);
                paramDestination.Value = Destination;
                cmd.Parameters.Add(paramDestination);

                MySqlParameter paramid = new MySqlParameter("@id", MySqlDbType.Int32);
                paramid.Value = id;
                cmd.Parameters.Add(paramid);

                resultRow = cmd.ExecuteNonQuery();
            }
            if (resultRow>0)
            {
                MessageBox.Show("저장");
                GetEmployees();
            }
        }
    }
}
