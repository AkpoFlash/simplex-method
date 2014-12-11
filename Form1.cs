using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WindowsFormsApplication3
{
    public partial class Main_form : Form
    {
        const int MAX_SIZE = 9;
        public Panel graph = new Panel();
        public Graphics draw_rect;
        public Button create_graph = new Button();
        public Point[] x_y = new Point[MAX_SIZE * MAX_SIZE];
        public NumericUpDown Const = new NumericUpDown(); // Константа целевой функции
        public Label Const_lab = new Label(); // Символ константы целевой функции
        public Label Obj_func_lab = new Label(); // Заголовок целевой функции
        public Label result_lab = new Label(); // Итоговое значение
        public Label Coeffic_var_lab = new Label(); // Заголовок полей коэффициентов при переменных
        public TextBox fx = new TextBox(); // Поле вывода Fx
        public TextBox free = new TextBox(); // Поле вывода свободных членов
        public NumericUpDown[,] cell_tmp = new NumericUpDown[MAX_SIZE, MAX_SIZE]; // Поля для хранения коэффициентов при Х
        public TextBox[] variable = new TextBox[MAX_SIZE*2]; // Поля для хранения коэффициентов при Х для исскуственного базиса
        public TextBox[] basis = new TextBox[MAX_SIZE]; // Поля для хранения коэффициентов при Х для исскуственного базиса
        public NumericUpDown[] funct_field_tmp = new NumericUpDown[MAX_SIZE]; // Поля для записи коэффициентов при Х в целевой функции
        public Label[,] x = new Label[MAX_SIZE, MAX_SIZE]; // Х1, Х2, Х3 и т.д.
        public TextBox[,] matrix = new TextBox[MAX_SIZE*2+1, MAX_SIZE*2+1]; // Итоговая матрица
        public TextBox[,] matrix_tmp = new TextBox[MAX_SIZE * 2 + 1, MAX_SIZE * 2 + 1]; // Матрица для промежуточных рассчетов
        public Label[] funct_char = new Label[MAX_SIZE]; // Символы выводимые с целефой функцией Х1, Х2, -> и т.д.
        public ComboBox extremum = new ComboBox(); // Поле варианта MAX или MIN при целевой функции
        public ComboBox[] compare = new ComboBox[MAX_SIZE]; // Поле знака сравнения при ограничении
        public NumericUpDown[] limit_value_tmp = new NumericUpDown[MAX_SIZE]; // Поле значений ограничений

        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_form));

        public short count_point = 0;
        public short count_point2 = 0;
        public double scale_x = 1;
        public double scale_y = 1;
        public double scale_f_x = 1;
        public double scale_f_y = 1;
        short num_unknow, limit;
        short i, j;
        short current_page = 1;
                    

        // Main_form ------------------------------------------------------------------------------------------------------------------------------------
        public Main_form()
        {
            InitializeComponent();
        }
        // -----------------------------------------------------------------------------------------------------------------------------------------------


        // Main_form_Load --------------------------------------------------------------------------------------------------------------------------------
        private void Main_form_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseDataSet.Users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.databaseDataSet.Users);

            // Скрываем не нужные элементы
            Next_but.Visible = false;
            Next_but2.Visible = false;
            Back_but.Visible = false;
            Back_but2.Visible = false;

            // Инициализация объектов
            for (i = 0; i < MAX_SIZE; i++)
            {
                
                for (j = 0; j < MAX_SIZE; j++)
                {
                    cell_tmp[i, j] = new NumericUpDown();
                    x[i, j] = new Label();
                }
                basis[i] = new TextBox();
                funct_field_tmp[i] = new NumericUpDown();
                funct_char[i] = new Label();
                compare[i] = new ComboBox();
                compare[i].Items.AddRange(new object[] { "<=", ">=", "=" });
                limit_value_tmp[i] = new NumericUpDown();
            }

            extremum.Items.AddRange(new object[] { "Max", "Min" });

            for (i = 0; i < MAX_SIZE * 2; i++)
            {
                variable[i] = new TextBox();
            }

            for (i = 0; i < MAX_SIZE * 2 + 1; i++)
            {
                for (j = 0; j < MAX_SIZE * 2 + 1; j++)
                {
                    matrix[i, j] = new TextBox();
                    matrix_tmp[i, j] = new TextBox();
                }
            }


            // Создание второй странички
            if (Int16.TryParse(comboBox1.Text, out num_unknow) && Int16.TryParse(comboBox2.Text, out limit))
            {
                // Вывод на экран заголовка целевой функции
                Obj_func_lab.BackColor = System.Drawing.Color.FloralWhite;
                Obj_func_lab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                Obj_func_lab.Location = new System.Drawing.Point(7, 6);
                Obj_func_lab.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
                Obj_func_lab.Name = "Obj_func_lab";
                Obj_func_lab.Size = new System.Drawing.Size(628, 20);
                Obj_func_lab.Text = "The objective function F(x):";
                Obj_func_lab.Visible = false;
                panel3.Controls.Add(Obj_func_lab);

                // Вывод на экран заголовка полей коэффициентов при переменных
                Coeffic_var_lab.BackColor = System.Drawing.Color.FloralWhite;
                Coeffic_var_lab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                Coeffic_var_lab.Location = new System.Drawing.Point(7, 125);
                Coeffic_var_lab.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
                Coeffic_var_lab.Name = "Obj_func_lab";
                Coeffic_var_lab.Size = new System.Drawing.Size(628, 20);
                Coeffic_var_lab.Text = "Fill out the coefficients  of the variables:";
                Coeffic_var_lab.Visible = false;
                panel3.Controls.Add(Coeffic_var_lab);

                // Вывод на экран заголовка целевой функции
                Const_lab.BackColor = System.Drawing.Color.FloralWhite;
                Const_lab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                Const_lab.Location = new System.Drawing.Point(61, 85);
                Const_lab.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
                Const_lab.Name = "Const_lab";
                Const_lab.Size = new System.Drawing.Size(40, 20);
                Const_lab.Text = "С";
                Const_lab.Visible = false;
                panel3.Controls.Add(Const_lab);

                // Константа целевой функции
                Const.Location = new System.Drawing.Point(11, 85);
                Const.Size = new System.Drawing.Size(50, 20);
                Const.Name = "Const";
                Const.Maximum = 100000;
                Const.Minimum = -100000;
                Const.DecimalPlaces = 2;
                Const.Visible = false;
                panel3.Controls.Add(Const);
                

                // Вывод на экран данные функции
                for (i = 0; i < MAX_SIZE; i++)
                {
                    //Вывод на экран полей коэффициентов функции
                    funct_field_tmp[i].Location = new System.Drawing.Point(11 + i * 95, 45);
                    funct_field_tmp[i].Size = new System.Drawing.Size(50, 20);
                    funct_field_tmp[i].Name = "funct_field_tmp" + i.ToString();
                    funct_field_tmp[i].Maximum = 100000;
                    funct_field_tmp[i].Minimum = -100000;
                    funct_field_tmp[i].DecimalPlaces = 2;
                    funct_field_tmp[i].Visible = false;
                    panel3.Controls.Add(funct_field_tmp[i]);

                    //Вывод на экран символов при целефой функцией Х1, Х2, -> и т.д.
                    funct_char[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    funct_char[i].Location = new System.Drawing.Point(61 + i * 95, 45);
                    funct_char[i].Name = "X" + i.ToString() + j.ToString();

                    // Проверка на последний элемент что бы поставить на его место ->
                    if (MAX_SIZE - i > 1)
                    {
                        funct_char[i].Size = new System.Drawing.Size(45, 20);
                        funct_char[i].Text = "X" + i.ToString() + " +";
                    }
                    else
                    {
                        funct_char[i].Size = new System.Drawing.Size(50, 20);
                        funct_char[i].Text = "X" + i .ToString() + " ->";

                        // Вывод на экран поля варианта MAX или MIN при целевой функции
                        extremum.Text = "max";
                        extremum.Name = "extremum";
                        extremum.Size = new System.Drawing.Size(50, 20);
                        extremum.MaxLength = 3;
                        extremum.Visible = false;
                        panel3.Controls.Add(extremum);
                    }
                    funct_char[i].Visible = false;
                    panel3.Controls.Add(funct_char[i]);
                }


                for (i = 0; i < MAX_SIZE; i++)
                {
                    for (j = 0; j < MAX_SIZE; j++)
                    {

                        // Вывод на экран полей для хранения коэффициентов при Х
                        cell_tmp[i, j].Location = new System.Drawing.Point(11 + j * 95, 160 + i * 40);
                        cell_tmp[i, j].Size = new System.Drawing.Size(50, 20);
                        cell_tmp[i, j].Name = "cell_tmp" + i.ToString() + j.ToString();
                        cell_tmp[i, j].Maximum = 10000;
                        cell_tmp[i, j].Minimum = -10000;
                        cell_tmp[i, j].DecimalPlaces = 2;
                        cell_tmp[i, j].Visible = false;
                        panel3.Controls.Add(cell_tmp[i, j]);
                        
                        // Вывод на экран Х1, Х2, Х3 и т.д.
                        x[i, j].Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                        x[i, j].Location = new System.Drawing.Point(61 + j * 95, 160 + i * 40);
                        x[i, j].Name = "X" + i.ToString() + j.ToString();

                        // Проверка на последний элемент Х1, Х2, Х3 и т.д.
                        if (MAX_SIZE - j > 1)
                        {
                            x[i, j].Size = new System.Drawing.Size(45, 20);
                            x[i, j].Text = "X" + (j+1).ToString() + " +";
                        }
                        else
                        {
                            x[i, j].Size = new System.Drawing.Size(30, 20);
                            x[i, j].Text = "X" + (j+1).ToString();
                        }
                        x[i, j].Visible = false;
                        panel3.Controls.Add(x[i, j]);
                    }

                    // Вывод на экран поля знака сравнения при ограничении
                    compare[i].MaxLength = 2;
                    compare[i].Name = "compare" + i;
                    compare[i].Size = new System.Drawing.Size(40, 21);
                    compare[i].Text = "<=";
                    compare[i].Visible = false;
                    panel3.Controls.Add(compare[i]);

                    // Вывод на экран поля значений ограничений
                    limit_value_tmp[i].Name = "limit_value_tmp" + i;
                    limit_value_tmp[i].Size = new System.Drawing.Size(50, 21);
                    limit_value_tmp[i].Maximum = 500000;
                    limit_value_tmp[i].Minimum = -500000;
                    limit_value_tmp[i].DecimalPlaces = 2;
                    limit_value_tmp[i].Visible = false;
                    panel3.Controls.Add(limit_value_tmp[i]);
                }
            }

            // Создание третьей странички
            if (Int16.TryParse(comboBox1.Text, out num_unknow) && Int16.TryParse(comboBox2.Text, out limit))
            {
                // Вывод на экран заголовка полей коэффициентов при переменных
                result_lab.BackColor = System.Drawing.Color.OldLace;
                result_lab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                result_lab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                result_lab.Location = new System.Drawing.Point(11, 280);
                result_lab.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
                result_lab.Name = "result_lab";
                result_lab.Text = "Result of the decision:\n";
                result_lab.Visible = false;
                panel3.Controls.Add(result_lab);

                create_graph.Location = new System.Drawing.Point(250, 280);
                create_graph.Name = "Login";
                create_graph.Size = new System.Drawing.Size(90, 23);
                create_graph.TabIndex = 3;
                create_graph.Text = "Darw Graph";
                create_graph.UseVisualStyleBackColor = true;
                create_graph.Visible = false;
                create_graph.Click += new System.EventHandler(this.Create_Graph_Click);
                panel3.Controls.Add(create_graph);

                for (i = 0; i < MAX_SIZE * 2 + 1; i++)
                {
                    for (j = 0; j < MAX_SIZE * 2 + 1; j++)
                    {
                        // Поля для итоговой матрицы
                        matrix[i, j].Size = new System.Drawing.Size(45, 20);
                        matrix[i, j].Name = "matrix" + i;
                        matrix[i, j].MaxLength = 5;
                        matrix[i, j].Enabled = false;
                        matrix[i, j].Visible = false;
                        panel3.Controls.Add(matrix[i, j]);

                        // Матрица для промежуточных рассчетов
                        matrix_tmp[i, j].Size = new System.Drawing.Size(45, 20);
                        matrix_tmp[i, j].Name = "matrix_tmp" + i;
                        matrix_tmp[i, j].MaxLength = 5;
                        matrix_tmp[i, j].Enabled = false;
                        matrix_tmp[i, j].Visible = false;
                        panel3.Controls.Add(matrix_tmp[i, j]);
                    }
                }

                for (i = 0; i < MAX_SIZE * 2; i++)
                {

                    //Вывод на экран полей коэффициентов при Х
                    variable[i].Size = new System.Drawing.Size(45, 20);
                    variable[i].Name = "variable" + i;
                    variable[i].Text = "X" + (i + 1);
                    variable[i].Enabled = false;
                    variable[i].Visible = false;
                    panel3.Controls.Add(variable[i]);
                     
                }

                for (i = 0; i < MAX_SIZE; i++)
                {
                    //Поле для базиса
                    basis[i].Size = new System.Drawing.Size(45, 20);
                    basis[i].Name = "basis" + i;
                    basis[i].Text = "X" + (i + 1);
                    basis[i].Enabled = false;
                    basis[i].Visible = false;
                    panel3.Controls.Add(basis[i]);
                    
                }

                // Поле вывода Fx
                fx.Size = new System.Drawing.Size(45, 20);
                fx.Name = "Fx";
                fx.Text = "F(x)";
                fx.Enabled = false;
                fx.Visible = false;
                panel3.Controls.Add(fx);

                // Поле вывода свободных членов
                free.Size = new System.Drawing.Size(45, 20);
                free.Name = "Free";
                free.Text = "Free";
                free.Enabled = false;
                free.Visible = false;
                panel3.Controls.Add(free);

            }
        }
        // -----------------------------------------------------------------------------------------------------------------------------------------------


        // Login_Click -----------------------------------------------------------------------------------------------------------------------------------
        private void Login_Click(object sender, EventArgs e)
        {
            int i;
            error_lab.Visible = true;

            for (i = 0; usersTableAdapter.get_user(i) != null; i++)
            {
                if (username_login.Text == (string)usersTableAdapter.get_user(i) && password_login.Text == (string)usersTableAdapter.get_password(i))
                {
                    // Убираем не нужные элементы
                    username_lab.Visible = false;
                    password_lab.Visible = false;
                    username_login.Visible = false;
                    password_login.Visible = false;
                    Login.Visible = false;
                    Registration.Visible = false;
                    error_lab.Text = "";
                    error_lab.Visible = false;

                    // Выводим основные элементы
                    Header_lab.Visible = true;
                    Limit_lab.Visible = true;
                    Num_unknow_lab.Visible = true;
                    Next_but.Visible = true;
                    BgColor.Visible = true;
                    Font_but.Visible = true;
                    comboBox1.Visible = true;
                    comboBox2.Visible = true;
                    exit_but.Visible = true;

                    if (Convert.ToInt32(usersTableAdapter.get_privileges(i)) == 1)
                    {
                        del_user.Visible = true;
                        privileges_but.Visible = true;
                    }
                    else
                    {
                        del_user.Visible = false;
                        privileges_but.Visible = false;
                    }
                    
                    return;
                }
            }

            // Если ввели неправильно
            password_login.Text = "";
            error_lab.Text = "Login or password incorrect";
        }
        // -----------------------------------------------------------------------------------------------------------------------------------------------


        // Registration_Click ----------------------------------------------------------------------------------------------------------------------------
        private void Registration_Click(object sender, EventArgs e)
        {
            int i;

            for (i = 0; usersTableAdapter.get_user(i) != null; i++)
            {
                if(username_login.Text == "" || password_login.Text == "")
                {
                    // Если ввели неправильно
                    error_lab.Text = "Incorrect data";
                    return;
                }
                if (username_login.Text == (string)usersTableAdapter.get_user(i))
                {
                    // Если ввели неправильно
                    password_login.Text = "";
                    error_lab.Text = "This user is already registered";
                    return;
                }
            }

            usersTableAdapter.set_user(i,username_login.Text, password_login.Text);

            // Убираем не нужные элементы
            username_lab.Visible = false;
            password_lab.Visible = false;
            username_login.Visible = false;
            password_login.Visible = false;
            Login.Visible = false;
            Registration.Visible = false;
            error_lab.Text = "";
            error_lab.Visible = false;

            // Выводим основные элементы
            Header_lab.Visible = true;
            Limit_lab.Visible = true;
            Num_unknow_lab.Visible = true;
            Next_but.Visible = true;
            BgColor.Visible = true;
            Font_but.Visible = true;
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            exit_but.Visible = true;
        }
        // -----------------------------------------------------------------------------------------------------------------------------------------------


        // del_user_Click --------------------------------------------------------------------------------------------------------------------------------
        private void del_user_Click(object sender, EventArgs e)
        {
            // Скрываем старые элементы
            switch (current_page)
            {
                case 1:
                    Header_lab.Visible = false;
                    Limit_lab.Visible = false;
                    Num_unknow_lab.Visible = false;
                    Back_but2.Visible = false;
                    Next_but.Visible = false;
                    Next_but2.Visible = false;
                    Back_but.Visible = false;
                    BgColor.Visible = false;
                    Font_but.Visible = false;
                    comboBox1.Visible = false;
                    comboBox2.Visible = false;
                    del_user.Visible = false;
                    exit_but.Visible = false;
                    privileges_but.Visible = false;
                    break;
                
                case 2:
                    Obj_func_lab.Visible = false;
                    Coeffic_var_lab.Visible = false;
                    Const.Visible = false;
                    Const_lab.Visible = false;
                    Back_but2.Visible = false;
                    Next_but.Visible = false;
                    Next_but2.Visible = false;
                    Back_but.Visible = false;
                    BgColor.Visible = false;
                    Font_but.Visible = false;
                    del_user.Visible = false;
                    exit_but.Visible = false;
                    privileges_but.Visible = false;
                    if (Int16.TryParse(comboBox1.Text, out num_unknow) && Int16.TryParse(comboBox2.Text, out limit))
                    {
                        for (i = 0; i < num_unknow; i++)
                        {
                            funct_field_tmp[i].Visible = false;
                            funct_char[i].Visible = false;
                        }

                        extremum.Visible = false;

                        for (i = 0; i < limit; i++)
                        {
                            for (j = 0; j < num_unknow; j++)
                            {
                                cell_tmp[i, j].Visible = false;
                                x[i, j].Visible = false;
                            }
                            compare[i].Visible = false;
                            limit_value_tmp[i].Visible = false;
                        }
                    }
                    break;

                case 3:
                    Back_but2.Visible = false;
                    Next_but.Visible = false;
                    Next_but2.Visible = false;
                    Back_but.Visible = false;
                    BgColor.Visible = false;
                    Font_but.Visible = false;
                    del_user.Visible = false;
                    exit_but.Visible = false;
                    privileges_but.Visible = false;
                    if (Int16.TryParse(comboBox1.Text, out num_unknow) && Int16.TryParse(comboBox2.Text, out limit))
                    {
                        result_lab.Visible = false;

                        for (i = 0; i < num_unknow + limit; i++)
                        {
                            variable[i].Visible = false;
                        }

                        for (i = 0; i < limit; i++)
                        {
                            basis[i].Visible = false;
                        }

                        fx.Visible = false;

                        free.Visible = false;

                        for (i = 0; i < limit + 1; i++)
                        {
                            for (j = 0; j < num_unknow + limit + 1; j++)
                            {
                                matrix[i, j].Visible = false;
                            }
                        }

                        if (num_unknow == 2 && limit > 2)
                        {
                            create_graph.Visible = false;
                            graph.Visible = false;
                        }
                    }
                    break;
            }

            // Отображаем новые элементы
            username_login.Text = "";
            Back_setting.Visible = true;
            username_login.Visible = true;
            username_lab.Visible = true;
            delete_but.Visible = true;
            
        }
        // -----------------------------------------------------------------------------------------------------------------------------------------------


        // Back_setting_Click --------------------------------------------------------------------------------------------------------------------------------
        private void Back_setting_Click(object sender, EventArgs e)
        {
            // Скрываем старые элементы
            Back_setting.Visible = false;
            username_login.Visible = false;
            username_lab.Visible = false;
            delete_but.Visible = false;
            make_admin_but.Visible = false;
            make_user_but.Visible = false;


            // Отображаем новые элементы
            switch (current_page)
            {
                case 1:
                    Header_lab.Visible = true;
                    Limit_lab.Visible = true;
                    Num_unknow_lab.Visible = true;
                    Next_but.Visible = true;
                    BgColor.Visible = true;
                    Font_but.Visible = true;
                    comboBox1.Visible = true;
                    comboBox2.Visible = true;
                    del_user.Visible = true;
                    exit_but.Visible = true;
                    privileges_but.Visible = true;
                    break;
                
                case 2:
                    Obj_func_lab.Visible = true;
                    Coeffic_var_lab.Visible = true;
                    Const.Visible = true;
                    Const_lab.Visible = true;
                    Next_but2.Visible = true;
                    Back_but.Visible = true;
                    BgColor.Visible = true;
                    Font_but.Visible = true;
                    del_user.Visible = true;
                    exit_but.Visible = true;
                    privileges_but.Visible = true;
                    if (Int16.TryParse(comboBox1.Text, out num_unknow) && Int16.TryParse(comboBox2.Text, out limit))
                    {
                        for (i = 0; i < num_unknow; i++)
                        {
                            funct_field_tmp[i].Visible = true;
                            funct_char[i].Visible = true;
                        }

                        extremum.Visible = true;

                        for (i = 0; i < limit; i++)
                        {
                            for (j = 0; j < num_unknow; j++)
                            {
                                cell_tmp[i, j].Visible = true;
                                x[i, j].Visible = true;
                            }
                            compare[i].Visible = true;
                            limit_value_tmp[i].Visible = true;
                        }
                    }
                    break;

                case 3:
                    Back_but2.Visible = true;
                    BgColor.Visible = true;
                    Font_but.Visible = true;
                    del_user.Visible = true;
                    exit_but.Visible = true;
                    privileges_but.Visible = true;
                    if (Int16.TryParse(comboBox1.Text, out num_unknow) && Int16.TryParse(comboBox2.Text, out limit))
                    {
                        result_lab.Visible = true;

                        for (i = 0; i < num_unknow + limit; i++)
                        {
                            variable[i].Visible = true;
                        }

                        for (i = 0; i < limit; i++)
                        {
                            basis[i].Visible = true;
                        }

                        fx.Visible = true;

                        free.Visible = true;

                        for (i = 0; i < limit + 1; i++)
                        {
                            for (j = 0; j < num_unknow + limit + 1; j++)
                            {
                                matrix[i, j].Visible = true;
                            }
                        }

                        if (num_unknow == 2 && limit > 2)
                        {
                            create_graph.Visible = true;
                        }
                    }
                    break;
            }
        }
        // -----------------------------------------------------------------------------------------------------------------------------------------------


        // delete_but_Click ------------------------------------------------------------------------------------------------------------------------------
        private void delete_but_Click(object sender, EventArgs e)
        { 
            usersTableAdapter.del_user(username_login.Text);
            username_login.Text = "";
        }
        // -----------------------------------------------------------------------------------------------------------------------------------------------


        // exit_but_Click --------------------------------------------------------------------------------------------------------------------------------
        private void exit_but_Click(object sender, EventArgs e)
        {
            // Скрываем старые элементы
            switch (current_page)
            {
                case 1:
                    Header_lab.Visible = false;
                    Limit_lab.Visible = false;
                    Num_unknow_lab.Visible = false;
                    Back_but2.Visible = false;
                    Next_but.Visible = false;
                    Next_but2.Visible = false;
                    Back_but.Visible = false;
                    BgColor.Visible = false;
                    Font_but.Visible = false;
                    comboBox1.Visible = false;
                    comboBox2.Visible = false;
                    del_user.Visible = false;
                    exit_but.Visible = false;
                    privileges_but.Visible = false;
                    break;
                
                case 2:
                    Obj_func_lab.Visible = false;
                    Coeffic_var_lab.Visible = false;
                    Const.Visible = false;
                    Const_lab.Visible = false;
                    Back_but2.Visible = false;
                    Next_but.Visible = false;
                    Next_but2.Visible = false;
                    Back_but.Visible = false;
                    BgColor.Visible = false;
                    Font_but.Visible = false;
                    del_user.Visible = false;
                    exit_but.Visible = false;
                    privileges_but.Visible = false;
                    if (Int16.TryParse(comboBox1.Text, out num_unknow) && Int16.TryParse(comboBox2.Text, out limit))
                    {
                        for (i = 0; i < num_unknow; i++)
                        {
                            funct_field_tmp[i].Visible = false;
                            funct_char[i].Visible = false;
                        }

                        extremum.Visible = false;

                        for (i = 0; i < limit; i++)
                        {
                            for (j = 0; j < num_unknow; j++)
                            {
                                cell_tmp[i, j].Visible = false;
                                x[i, j].Visible = false;
                            }
                            compare[i].Visible = false;
                            limit_value_tmp[i].Visible = false;
                        }
                    }
                    break;

                case 3:
                    Back_but2.Visible = false;
                    Next_but.Visible = false;
                    Next_but2.Visible = false;
                    Back_but.Visible = false;
                    BgColor.Visible = false;
                    Font_but.Visible = false;
                    del_user.Visible = false;
                    exit_but.Visible = false;
                    privileges_but.Visible = false;
                    if (Int16.TryParse(comboBox1.Text, out num_unknow) && Int16.TryParse(comboBox2.Text, out limit))
                    {
                        result_lab.Visible = false;

                        for (i = 0; i < num_unknow + limit; i++)
                        {
                            variable[i].Visible = false;
                        }

                        for (i = 0; i < limit; i++)
                        {
                            basis[i].Visible = false;
                        }

                        fx.Visible = false;

                        free.Visible = false;

                        for (i = 0; i < limit + 1; i++)
                        {
                            for (j = 0; j < num_unknow + limit + 1; j++)
                            {
                                matrix[i, j].Visible = false;
                            }
                        }

                        if (num_unknow == 2 && limit > 2)
                        {
                            create_graph.Visible = false;
                            graph.Visible = false;
                        }
                    }
                    break;
            }

            // Отображаем новые элементы
            username_login.Text = "";
            password_login.Text = "";
            username_lab.Visible = true;
            password_lab.Visible = true;
            username_login.Visible = true;
            password_login.Visible = true;
            Login.Visible = true;
            Registration.Visible = true;
        }
        // -----------------------------------------------------------------------------------------------------------------------------------------------


        // privileges_but_Click --------------------------------------------------------------------------------------------------------------------------
        private void privileges_but_Click(object sender, EventArgs e)
        {
            // Скрываем старые элементы
            switch (current_page)
            {
                case 1:
                    Header_lab.Visible = false;
                    Limit_lab.Visible = false;
                    Num_unknow_lab.Visible = false;
                    Back_but2.Visible = false;
                    Next_but.Visible = false;
                    Next_but2.Visible = false;
                    Back_but.Visible = false;
                    BgColor.Visible = false;
                    Font_but.Visible = false;
                    comboBox1.Visible = false;
                    comboBox2.Visible = false;
                    del_user.Visible = false;
                    exit_but.Visible = false;
                    privileges_but.Visible = false;
                    break;

                case 2:
                    Obj_func_lab.Visible = false;
                    Coeffic_var_lab.Visible = false;
                    Const.Visible = false;
                    Const_lab.Visible = false;
                    Back_but2.Visible = false;
                    Next_but.Visible = false;
                    Next_but2.Visible = false;
                    Back_but.Visible = false;
                    BgColor.Visible = false;
                    Font_but.Visible = false;
                    del_user.Visible = false;
                    exit_but.Visible = false;
                    privileges_but.Visible = false;
                    if (Int16.TryParse(comboBox1.Text, out num_unknow) && Int16.TryParse(comboBox2.Text, out limit))
                    {
                        for (i = 0; i < num_unknow; i++)
                        {
                            funct_field_tmp[i].Visible = false;
                            funct_char[i].Visible = false;
                        }

                        extremum.Visible = false;

                        for (i = 0; i < limit; i++)
                        {
                            for (j = 0; j < num_unknow; j++)
                            {
                                cell_tmp[i, j].Visible = false;
                                x[i, j].Visible = false;
                            }
                            compare[i].Visible = false;
                            limit_value_tmp[i].Visible = false;
                        }
                    }
                    break;

                case 3:
                    Back_but2.Visible = false;
                    Next_but.Visible = false;
                    Next_but2.Visible = false;
                    Back_but.Visible = false;
                    BgColor.Visible = false;
                    Font_but.Visible = false;
                    del_user.Visible = false;
                    exit_but.Visible = false;
                    privileges_but.Visible = false;
                    if (Int16.TryParse(comboBox1.Text, out num_unknow) && Int16.TryParse(comboBox2.Text, out limit))
                    {
                        result_lab.Visible = false;

                        for (i = 0; i < num_unknow + limit; i++)
                        {
                            variable[i].Visible = false;
                        }

                        for (i = 0; i < limit; i++)
                        {
                            basis[i].Visible = false;
                        }

                        fx.Visible = false;

                        free.Visible = false;

                        for (i = 0; i < limit + 1; i++)
                        {
                            for (j = 0; j < num_unknow + limit + 1; j++)
                            {
                                matrix[i, j].Visible = false;
                            }
                        }

                        if (num_unknow == 2 && limit > 2)
                        {
                            create_graph.Visible = false;
                            graph.Visible = false;
                        }
                    }
                    break;
            }

            // Отображаем новые элементы
            username_login.Text = "";
            make_admin_but.Visible = true;
            username_login.Visible = true;
            username_lab.Visible = true;
            make_admin_but.Visible = true;
            make_user_but.Visible = true;
            Back_setting.Visible = true;
        }
        // -----------------------------------------------------------------------------------------------------------------------------------------------


        // make_admin_but_Click --------------------------------------------------------------------------------------------------------------------------
        private void make_admin_but_Click(object sender, EventArgs e)
        {
            usersTableAdapter.make_admin(username_login.Text);
            username_login.Text = "";
        }
        // -----------------------------------------------------------------------------------------------------------------------------------------------


        // make_user_but_Click ---------------------------------------------------------------------------------------------------------------------------
        private void make_user_but_Click(object sender, EventArgs e)
        {
            usersTableAdapter.make_user(username_login.Text);
            username_login.Text = "";
        }
        // -----------------------------------------------------------------------------------------------------------------------------------------------


        // fontDialog1_Apply -----------------------------------------------------------------------------------------------------------------------------
        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }
        // -----------------------------------------------------------------------------------------------------------------------------------------------


        // Next_but_Click --------------------------------------------------------------------------------------------------------------------------------
        private void Next_but_Click(object sender, EventArgs e)
        {
            current_page = 2;

            // Скрываем не нужные элементы
            Back_but2.Visible = false;
            Next_but.Visible = false;
            Header_lab.Visible = false;
            Num_unknow_lab.Visible = false;
            Limit_lab.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;

            // Выводим новые элементы
            Back_but.Visible = true;
            Next_but2.Visible = true;

            if (Int16.TryParse(comboBox1.Text, out num_unknow) && Int16.TryParse(comboBox2.Text, out limit))
            {
                //Выводим содержимое второй страницы
                Obj_func_lab.Visible = true;
                Coeffic_var_lab.Visible = true;
                Const.Visible = true;
                Const_lab.Visible = true;

                for (i = 0; i < num_unknow; i++)
                {
                    funct_field_tmp[i].Visible = true;
                    funct_char[i].Visible = true;
                    if (num_unknow - i > 1)
                    {
                        funct_char[i].Size = new System.Drawing.Size(45, 20);
                        funct_char[i].Text = "X" + (i + 1).ToString() + " +";
                    }
                    else
                    {
                        funct_char[i].Size = new System.Drawing.Size(50, 20);
                        funct_char[i].Text = "X" + (i + 1).ToString() + " ->";
                        extremum.Location = new System.Drawing.Point(111 + i * 95, 45);
                    }
                }

                extremum.Visible = true;

                for (i = 0; i < limit; i++)
                {
                    for (j = 0; j < num_unknow; j++)
                    {
                        cell_tmp[i, j].Visible = true;
                        x[i, j].Visible = true;
                        if (num_unknow - j > 1)
                        {
                            x[i, j].Size = new System.Drawing.Size(45, 20);
                            x[i, j].Text = "X" + (j + 1).ToString() + " +";
                        }
                        else
                        {
                            x[i, j].Size = new System.Drawing.Size(30, 20);
                            x[i, j].Text = "X" + (j + 1).ToString();
                        }
                    }
                    compare[i].Location = new System.Drawing.Point(10 + j * 95, 160 + i * 40);
                    compare[i].Visible = true;
                    limit_value_tmp[i].Location = new System.Drawing.Point(60 + j * 95, 160 + i * 40);
                    limit_value_tmp[i].Visible = true;
                }
            }
        }
        // -----------------------------------------------------------------------------------------------------------------------------------------------


        // Back_but_Click --------------------------------------------------------------------------------------------------------------------------------
        private void Back_but_Click(object sender, EventArgs e)
        {
            current_page = 1;

            // Скрываем не нужные элементы
            Back_but2.Visible = false;
            Next_but2.Visible = false;
            Back_but.Visible = false;

            if (Int16.TryParse(comboBox1.Text, out num_unknow) && Int16.TryParse(comboBox2.Text, out limit))
            {
                //Скрываем содержимое второй страницы
                Obj_func_lab.Visible = false;
                Coeffic_var_lab.Visible = false;
                Const.Visible = false;
                Const_lab.Visible = false;

                for (i = 0; i < num_unknow; i++)
                {
                    funct_field_tmp[i].Visible = false;
                    funct_char[i].Visible = false;
                }

                extremum.Visible = false;

                for (i = 0; i < limit; i++)
                {
                    for (j = 0; j < num_unknow; j++)
                    {
                        cell_tmp[i, j].Visible = false;
                        x[i, j].Visible = false;
                    }
                    compare[i].Visible = false;
                    limit_value_tmp[i].Visible = false;
                }
            }

            // Выводим новые элементы
            Header_lab.Visible = true;
            Num_unknow_lab.Visible = true;
            Limit_lab.Visible = true;
            comboBox1.Visible = true; 
            comboBox2.Visible = true;
            Next_but.Visible = true;
        }
        // -----------------------------------------------------------------------------------------------------------------------------------------------


        // Next_but2_Click -------------------------------------------------------------------------------------------------------------------------------
        private void Next_but2_Click(object sender, EventArgs e)
        {
            current_page = 3;

            // Скрываем старые элементы
            Next_but.Visible = false;
            Next_but2.Visible = false;
            Back_but.Visible = false;

            // Выводим новые элементы
            Back_but2.Visible = true;


            for (i = 0; i < limit; i++)
            {
                basis[i].Text = "X" + (i + 1 + num_unknow);
            }
            
            
            if (Int16.TryParse(comboBox1.Text, out num_unknow) && Int16.TryParse(comboBox2.Text, out limit))
            {
                result_lab.Text = "Result of the decision:\n";

                //Скрываем содержимое второй страницы
                Obj_func_lab.Visible = false;
                Coeffic_var_lab.Visible = false;

                Const.Visible = false;
                Const_lab.Visible = false;

                for (i = 0; i < num_unknow; i++)
                {
                    funct_field_tmp[i].Visible = false;
                    funct_char[i].Visible = false;
                }

                extremum.Visible = false;


                for (i = 0; i < limit; i++)
                {
                    for (j = 0; j < num_unknow; j++)
                    {
                        cell_tmp[i, j].Visible = false;
                        x[i, j].Visible = false;
                    }
                    compare[i].Visible = false;
                    limit_value_tmp[i].Visible = false;
                }

                // Заполняем матрицу значениями
                for (i = 0; i < limit; i++)
                {
                    for (j = 0; j < num_unknow; j++)
                    {
                        matrix[i, j].Text = matrix_tmp[i, j].Text = "" + cell_tmp[i, j].Value;
                        matrix[limit, j].Text = matrix_tmp[limit, j].Text = "" + funct_field_tmp[j].Value;
                    }
                    matrix[i, num_unknow + limit].Text = matrix_tmp[i, num_unknow + limit].Text = "" + limit_value_tmp[i].Value;
                }

                matrix[i, num_unknow + limit].Text = matrix_tmp[i, num_unknow + limit].Text = "" + 0;

                for (i = 0; i < limit + 1; i++)
                {
                    for (j = num_unknow; j < num_unknow + limit; j++)
                    {
                        if (j - num_unknow == i)
                        {
                            matrix[i, j].Text = matrix_tmp[i, j].Text = "" + 1;
                        }
                        else
                        {
                            matrix[i, j].Text = matrix_tmp[i, j].Text = "" + 0;
                        }
                    }
                }

                // Находим точки, для графического метода
                if (num_unknow == 2 && limit > 2)
                {
                    int[,] equation = new int[limit, num_unknow + 1];
                    int q;
                    for (i = 0; i < limit; i++)
                    {
                        equation[i, 0] = Convert.ToInt32(Convert.ToDouble(matrix[i, 0].Text));
                        equation[i, 1] = Convert.ToInt32(Convert.ToDouble(matrix[i, 1].Text));
                        equation[i, 2] = Convert.ToInt32(Convert.ToDouble(matrix[i, num_unknow + limit].Text));
                    }

                    // Вычисляем необходимый масштаб
                    double max_x = 1;
                    double max_y = 1;
                    scale_x = 1;
                    scale_y = 1;
                    count_point = 0;

                    for (i = 0; i < limit; i++)
                    {
                        for (q = i + 1; q < num_unknow + 1; q++)
                        {
                            if ((equation[i, 0] * equation[q, 1] - equation[q, 0] * equation[i, 1]) != 0 && max_x < Math.Abs((equation[i, 2] * equation[q, 1] - equation[q, 2] * equation[i, 1]) / (equation[i, 0] * equation[q, 1] - equation[q, 0] * equation[i, 1])))
                            {
                                max_x = Math.Abs((equation[i, 2] * equation[q, 1] - equation[q, 2] * equation[i, 1]) / (equation[i, 0] * equation[q, 1] - equation[q, 0] * equation[i, 1]));
                            }
                            if ((equation[i, 1] * equation[q, 0] - equation[q, 1] * equation[i, 0]) != 0 && max_y < Math.Abs((equation[i, 2] * equation[q, 0] - equation[q, 2] * equation[i, 0]) / (equation[i, 1] * equation[q, 0] - equation[q, 1] * equation[i, 0])))
                            {
                                max_y = Math.Abs((equation[i, 2] * equation[q, 0] - equation[q, 2] * equation[i, 0]) / (equation[i, 1] * equation[q, 0] - equation[q, 1] * equation[i, 0]));
                            }
                        }
                    }

                    if (max_x < 175)
                    {
                        while ((scale_x + 1) * max_x < 175)
                        {
                            scale_x += 1;
                        }
                    }
                    else
                    {
                        while ((scale_x - 1) * max_x > 175)
                        {
                            scale_x -= 1;
                        }
                    }

                    if (max_y < 200)
                    {
                        while ((scale_y + 1) * max_y < 200)
                        {
                            scale_y += 1;
                        }
                    }
                    else
                    {
                        while ((scale_y - 1) * max_y > 200)
                        {
                            scale_y -= 1;
                        }
                    }


                    // Вычисляем пересечения с осями координат
                    int x;
                    int y;
   
                    // Вычисляем пересечения с линиями
                    for (i = 0, j = 0; i < limit; i++)
                    {
                        for (q = i+1; q < num_unknow + 1; q++)
                        {
                            if ((equation[i, 0] * equation[q, 1] - equation[q, 0] * equation[i, 1]) == 0 || (equation[i, 1] * equation[q, 0] - equation[q, 1] * equation[i, 0]) == 0)
                            {
                                j++;
                                continue;
                            }
                            x = 175 + Convert.ToInt32(scale_x * (equation[i, 2] * equation[q, 1] - equation[q, 2] * equation[i, 1]) / (equation[i, 0] * equation[q, 1] - equation[q, 0] * equation[i, 1]));
                            y = 200 - Convert.ToInt32(scale_y * (equation[i, 2] * equation[q, 0] - equation[q, 2] * equation[i, 0]) / (equation[i, 1] * equation[q, 0] - equation[q, 1] * equation[i, 0]));
                            x_y[j++] = new Point(x, y);
                        }      
                    }
                    count_point = j;
                }


                // Меняем знаки у коэффициентов на противоположные если функция стремится к минимуму
                if (extremum.Text == "Max")
                {
                    for (j = 0; j < num_unknow; j++)
                    {
                        matrix[limit, j].Text = matrix_tmp[limit, j].Text = "" + (-Convert.ToDouble(matrix[limit, j].Text));
                    }
                }

                // Меняем знаки у свободных членов на противоположные если стоит знак '>='
                for (i = 0; i < limit; i++)
                {
                    if (compare[i].Text == ">=")
                    {
                        for (j = 0; j < num_unknow; j++)
                        {
                            matrix[i, j].Text = matrix_tmp[i, j].Text = "" + (-Convert.ToDouble(matrix[i, j].Text));
                        }
                        matrix[i, num_unknow + limit].Text = matrix_tmp[i, num_unknow + limit].Text = "" + (-Convert.ToDouble(matrix[i, num_unknow + limit].Text));
                    }
                    if (compare[i].Text == "=")
                    {
                        for (j = num_unknow; j < num_unknow + limit; j++)
                        {
                            matrix[i, j].Text = matrix_tmp[i, j].Text = "" + 0;
                        }
                    }
                }

                // Проверяем на допустимое решение
                while (true)
                {
                    double min_row = 0.0;
                    int min_row_id = -1;
                    double min_col = 0.0;
                    int min_col_id = -1;

                    // Ищем в столбце свободных членов отрицательный элемент
                    for (i = 0; i < limit; i++)
                    {
                        if (Convert.ToDouble(matrix[i, num_unknow + limit].Text) < min_row)
                        {
                            min_row = Convert.ToDouble(matrix[i, num_unknow + limit].Text);
                            min_row_id = i;
                        }
                    }
                    if (min_row == 0.0)
                    {
                        break;
                    }

                    if (min_row < 0.0)
                    {
                        // Ищем в строке отрицательный элемент
                        for (j = 0; j < num_unknow + limit; j++)   // Добавил + limit, возможны проблемы
                        {
                            if (Convert.ToDouble(matrix[min_row_id, j].Text) < min_col)
                            {
                                min_col = Convert.ToDouble(matrix[min_row_id, j].Text);
                                min_col_id = j;
                            }
                        }

                        // Если в строке нет отрицательных элементов
                        if (min_col == 0.0)
                        {
                            result_lab.Text += "No solutions\n";
                            break;
                        }

                        // Если в строке есть отрицательные элементы
                        if (min_col < 0.0)
                        {
                            basis[min_row_id].Text = variable[min_col_id].Text;

                            for (i = 0; i < limit + 1; i++)
                            {
                                for (j = 0; j < num_unknow + limit + 1; j++)
                                {
                                    if (i == min_row_id)
                                    {
                                        matrix[i, j].Text = "" + (Convert.ToDouble(matrix_tmp[i, j].Text) / Convert.ToDouble(matrix_tmp[min_row_id, min_col_id].Text));
                                    }
                                    else
                                    {
                                        matrix[i, j].Text = "" + (Convert.ToDouble(matrix_tmp[i, j].Text) - Convert.ToDouble(matrix_tmp[i, min_col_id].Text) * Convert.ToDouble(matrix_tmp[min_row_id, j].Text) / Convert.ToDouble(matrix_tmp[min_row_id, min_col_id].Text));
                                    }
                                }
                            }

                            for (i = 0; i < limit + 1; i++)
                            {
                                for (j = 0; j < num_unknow + limit + 1; j++)
                                {
                                    matrix_tmp[i, j].Text = matrix[i, j].Text;
                                }
                            }
                        }
                    }
                }

                // Проверяем на оптимальное решение
                while (true)
                {
                    double min_row = 100000.0;
                    int min_row_id = -1;
                    double min_col = 0.0;
                    int min_col_id = -1;

                    // Ищем в строке функции отрицательный элемент
                    for (j = 0; j < num_unknow + limit; j++)
                    {
                        if (Convert.ToDouble(matrix[limit, j].Text) < 0)
                        {
                            min_col = Convert.ToDouble(matrix[limit, j].Text);
                            min_col_id = j;
                        }
                    }

                    if (min_col == 0.0)
                    {
                        if (extremum.Text == "Min")
                        {
                            matrix[limit, limit + num_unknow].Text = "" + (-Convert.ToDouble(matrix[limit, limit + num_unknow].Text));
                        }

                        for (i = 0; i < limit; i++)
                        {
                            result_lab.Text += basis[i].Text + " = " + Math.Round(Convert.ToDouble(matrix[i, limit + num_unknow].Text), 2) + ";\n";
                        }
                        result_lab.Text += "Optimal solution: " + Math.Round(Convert.ToDouble(matrix[limit, limit + num_unknow].Text) + Convert.ToDouble(Const.Value), 2);
                        break;
                    }

                    if (min_col < 0.0)
                    {
                        // Ищем в столбце минимальное соотношение среди положительных
                        for (i = 0; i < limit + 1; i++)
                        {
                            if (Convert.ToDouble(matrix[i, min_col_id].Text) >= 0.0)
                            {
                                if (Convert.ToDouble(matrix[i, num_unknow + limit].Text) / Convert.ToDouble(matrix[i, min_col_id].Text) < min_row)
                                {
                                    min_row = Convert.ToDouble(matrix[i, num_unknow + limit].Text) / Convert.ToDouble(matrix[i, min_col_id].Text);
                                    min_row_id = i;
                                }
                            }
                        }

                        // Если в столбце нет положительных элементов
                        if (min_row == 100000.0)
                        {
                            result_lab.Text += "No solutions\n";
                            break;
                        }

                        // Если в строке есть положительных элементы

                        basis[min_row_id].Text = variable[min_col_id].Text;

                        for (i = 0; i < limit + 1; i++)
                        {
                            for (j = 0; j < num_unknow + limit + 1; j++)
                            {
                                if (i == min_row_id)
                                {
                                    matrix[i, j].Text = "" + (Convert.ToDouble(matrix_tmp[i, j].Text) / Convert.ToDouble(matrix_tmp[min_row_id, min_col_id].Text));
                                }
                                else
                                {
                                    matrix[i, j].Text = "" + (Convert.ToDouble(matrix_tmp[i, j].Text) - Convert.ToDouble(matrix_tmp[i, min_col_id].Text) * Convert.ToDouble(matrix_tmp[min_row_id, j].Text) / Convert.ToDouble(matrix_tmp[min_row_id, min_col_id].Text));
                                }
                            }
                        }

                        for (i = 0; i < limit + 1; i++)
                        {
                            for (j = 0; j < num_unknow + limit + 1; j++)
                            {
                                matrix_tmp[i, j].Text = matrix[i, j].Text;
                            }
                        }

                    }
                }

                //Выводим содержимое третьей страницы
                result_lab.Size = new System.Drawing.Size(220, (limit + 3) * 20);
                result_lab.Visible = true;

                for (i = 0; i < num_unknow + limit; i++)
                {
                    variable[i].Location = new System.Drawing.Point(56 + i * 45, 50);
                    variable[i].Visible = true;
                }

                for (i = 0; i < limit; i++)
                {
                    basis[i].Location = new System.Drawing.Point(11, 70 + i * 20);
                    basis[i].Visible = true;
                }

                fx.Location = new System.Drawing.Point(11, 70 + i * 20);
                fx.Visible = true;

                free.Location = new System.Drawing.Point(11 + (num_unknow + limit + 1) * 45, 50);
                free.Visible = true;


                for (i = 0; i < limit + 1; i++)
                {
                    for (j = 0; j < num_unknow + limit + 1; j++)
                    {
                        matrix[i, j].Text = "" + Math.Round(Convert.ToDouble(matrix[i, j].Text), 2);
                        matrix[i, j].Location = new System.Drawing.Point(56 + j * 45, 70 + i * 20);
                        matrix[i, j].Visible = true;
                    }
                }

                // Если заданны только две переменные, то есть плоскость.
                if (num_unknow == 2 && limit > 2)
                {
                    create_graph.Visible = true;
                }
            }
        }
        // -----------------------------------------------------------------------------------------------------------------------------------------------


        // Create_Graph_Click ----------------------------------------------------------------------------------------------------------------------------
        private void Create_Graph_Click(object sender, EventArgs e)
        {
            create_graph.Visible = false;

            graph.BackColor = System.Drawing.Color.White;
            graph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            graph.Location = new System.Drawing.Point(620, 30);
            graph.Name = "graph";
            graph.Size = new System.Drawing.Size(350, 400);
            graph.TabIndex = 9;
            graph.Visible = true;
            panel3.Controls.Add(graph);

            Pen pen_dop = new Pen(Color.Black, 1);
            Pen pen_main = new Pen(Color.Black, 2);
            Pen pen_funct = new Pen(Color.Red, 2);

            draw_rect = Graphics.FromHwnd(graph.Handle);
            draw_rect.DrawLine(pen_dop, 175, 0, 175, 400);
            draw_rect.DrawLine(pen_dop, 0, 200, 350, 200);
 

            // Отрисовываем фигуру
            for (i = Convert.ToInt16(1); i < count_point; i++)
            {
                draw_rect.DrawLine(pen_main, x_y[i - 1], x_y[i]);
            }

            draw_rect.DrawLine(pen_main, x_y[0], x_y[count_point-1]);

            double x_k = 175, y_k = 200, b = 0;
            double x = 175, y = 200;

            x_k = Convert.ToDouble(funct_field_tmp[0].Text);

            y_k =Convert.ToDouble(funct_field_tmp[1].Text);

            b = Convert.ToDouble(matrix[limit, limit + num_unknow].Text);

            if (x_k != 0)
            {
                x = b / x_k;
            }
            else
            {
                x = 0;
            }

            if (y_k != 0)
            {
                y = b / y_k;
            }
            else
            {
                y = 0;
            }

            // Масштаб для линии целевой функции
            scale_f_x = 1;
            scale_f_y = 1;
            double ratio = 1;

            if (x != 0 && y != 0) 
            { 
                ratio = (Math.Abs(x) >= Math.Abs(y)) ? y / x : x / y; 
            
                if (Math.Abs(x) < 175)
                {
                    while (scale_f_x * Math.Abs(x) < 175)
                    {
                        scale_f_x += 1;
                    }
                }
                else
                {
                    while (scale_f_x * Math.Abs(x) > 175)
                    {
                        scale_f_x -= 1;
                    }
                }

                if (y < 200)
                {
                    while (scale_f_y * Math.Abs(y) < 200)
                    {
                        scale_f_y += 1;
                    }
                }
                else
                {
                    while (scale_f_y * Math.Abs(y) > 200)
                    {
                        scale_f_y -= 1;
                    }
                }

                if (Math.Abs(x) > Math.Abs(y))
                {
                    scale_f_x *= Math.Abs(ratio);
                }
                else
                {
                    scale_f_y *= Math.Abs(ratio);
                }
            }


            // Определяем четверть графика
            if (x > 0 && y > 0)
            {
                draw_rect.DrawLine(pen_funct, 175, 200, 175 + Math.Abs(Convert.ToInt64(scale_f_x * x)), 200 + Math.Abs(Convert.ToInt64(scale_f_y * y))); 
                draw_rect.DrawLine(pen_funct, 175, 200, 175 - Math.Abs(Convert.ToInt64(scale_f_x * x)), 200 - Math.Abs(Convert.ToInt64(scale_f_y * y)));
            }
            if (x < 0 && y > 0)
            {
                draw_rect.DrawLine(pen_funct, 175, 200, 175 - Math.Abs(Convert.ToInt64(scale_f_x * x)), 200 + Math.Abs(Convert.ToInt64(scale_f_y * y))); 
                draw_rect.DrawLine(pen_funct, 175, 200, 175 + Math.Abs(Convert.ToInt64(scale_f_x * x)), 200 - Math.Abs(Convert.ToInt64(scale_f_y * y)));
            }
            if (x < 0 && y < 0)
            {
                draw_rect.DrawLine(pen_funct, 175, 200, 175 + Convert.ToInt64(scale_f_x * x), 200 + Convert.ToInt64(scale_f_y * y)); 
                draw_rect.DrawLine(pen_funct, 175, 200, 175 - Convert.ToInt64(scale_f_x * x), 200 - Convert.ToInt64(scale_f_y * y));
            }
            if (x > 0 && y < 0)
            {
                draw_rect.DrawLine(pen_funct, 175, 200, 175 - Math.Abs(Convert.ToInt64(scale_f_x * x)), 200 + Math.Abs(Convert.ToInt64(scale_f_y * y)));
                draw_rect.DrawLine(pen_funct, 175, 200, 175 + Math.Abs(Convert.ToInt64(scale_f_x * x)), 200 - Math.Abs(Convert.ToInt64(scale_f_y * y)));
            }
        }
        // -----------------------------------------------------------------------------------------------------------------------------------------------

        // Back_but2_Click -------------------------------------------------------------------------------------------------------------------------------
        private void Back_but2_Click(object sender, EventArgs e)
        {
            current_page = 2;

            // Скрываем не нужные элементы
            Back_but2.Visible = false;
            Next_but.Visible = false;
            graph.Visible = false;
            create_graph.Visible = false;

            draw_rect = null;

            for (i = 0; i < MAX_SIZE * MAX_SIZE; i++)
            {
                x_y[i] = new Point(0, 0);
            }

            // Выводим новые элементы
            Back_but.Visible = true;
            Next_but2.Visible = true;
            Const.Visible = true;
            Const_lab.Visible = true;
            
            //Скрываем содержимое третьей страницы
            result_lab.Visible = false;
            result_lab.Text = "Result of the decision:\n";

            for (i = 0; i < num_unknow + limit; i++)
            {
                variable[i].Visible = false;
            }

            for (i = 0; i < limit + 1; i++)
            {
                for (j = 0; j < num_unknow + limit + 1; j++)
                {
                    matrix[i, j].Text = "";
                    matrix[i, j].Visible = false;
                }
            }

            for (i = 0; i < limit; i++)
            {
                basis[i].Text = "X" + (i + 1 + num_unknow);
                basis[i].Visible = false;
            }
             
            fx.Visible = false;
            free.Visible = false;

            if (Int16.TryParse(comboBox1.Text, out num_unknow) && Int16.TryParse(comboBox2.Text, out limit))
            {
                //Выводим содержимое второй страницы
                Obj_func_lab.Visible = true;
                Coeffic_var_lab.Visible = true;

                for (i = 0; i < num_unknow; i++)
                {
                    funct_field_tmp[i].Visible = true;
                    funct_char[i].Visible = true;
                }

                extremum.Visible = true;

                for (i = 0; i < limit; i++)
                {
                    for (j = 0; j < num_unknow; j++)
                    {
                        cell_tmp[i, j].Visible = true;
                        x[i, j].Visible = true;
                    }
                    compare[i].Visible = true;
                    limit_value_tmp[i].Visible = true;
                }
            }
        }
        // -----------------------------------------------------------------------------------------------------------------------------------------------


        // Font_but_Click -------------------------------------------------------------------------------------------------------------------------------
        private void Font_but_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Header_lab.Font = Num_unknow_lab.Font = Limit_lab.Font = Obj_func_lab.Font = Coeffic_var_lab.Font = fontDialog.Font;
            }
        }
        // -----------------------------------------------------------------------------------------------------------------------------------------------


        // BgColor_Click ---------------------------------------------------------------------------------------------------------------------------------
        private void BgColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                // Изменение цвета панели и всех текстовых полей
                panel3.BackColor = Header_lab.BackColor = Num_unknow_lab.BackColor = Limit_lab.BackColor = Obj_func_lab.BackColor = Coeffic_var_lab.BackColor = Const_lab.BackColor = colorDialog1.Color;

            }
        }
        // -----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
