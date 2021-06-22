
namespace ProjectApp.Source
{
    class GlobalVariable
    {
        private static string _username;
        private static string _password;
        private static string _orderProdNO;
        private static int _accNO;

        public static int accNO
        {
            get { return _accNO; }
            set { _accNO = value; }
        }

        public static string username
        {
            get { return _username; }
            set { _username = value; }
        }

        public static string password
        {
            get { return _password; }
            set { _password = value; }
        }

        public static string orderProdNO
        {
            get { return _orderProdNO; }
            set { _orderProdNO = value; }
        }

        public static string sqlCon ="Server=SUWANON;Database=CuisineVision;Trusted_Connection=True;";

        public static CustomerForm cusForm = new CustomerForm();
        public static OrderedQueueForm orderedForm = new OrderedQueueForm();
        public static AdminForm adminForm = new AdminForm();
        public static OwnerForm ownerForm = new OwnerForm();
        public static LoginForm logForm = new LoginForm();
        public static LogoutForm outForm = new LogoutForm();
        public static OrderCoffeeForm cofForm = new OrderCoffeeForm();
        public static CalculatorForm calForm = new CalculatorForm();
        public static OrderFoodForm foodForm = new OrderFoodForm();
        public static AdminForm admForm = new AdminForm();
        public static cusOrderConfirmed cusOrdCon = new cusOrderConfirmed();
        public static ConfirmOrder conOrder = new ConfirmOrder();
        public static ConfirmPayment conPayment = new ConfirmPayment();
        public static PaymentForm payForm = new PaymentForm();
        public static EmployeeForm empForm = new EmployeeForm();
    }
}
