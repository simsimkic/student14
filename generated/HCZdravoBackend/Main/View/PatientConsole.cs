using Controller.ControllerAppointment;
using Controller.ControllerBlog;
using Controller.ControllerDean;
using Controller.ControllerDoctor;
using Controller.ControllerMedicalDocumentation;
using Controller.ControllerPatient;
using Controller.ControllerRoom;
using Controller.ControllerUser;
using Main.Repository.RepositoryUser;
using Main.View;
using Repository.RepositoryAppointment;
using Repository.RepositoryBlog;
using Repository.RepositoryDean;
using Repository.RepositoryDoctor;
using Repository.RepositoryMedicalDocumentation;
using Repository.RepositoryPatient;
using Repository.RepositoryRoom;
using Repository.RepositoryUser;
using Service.ServiceAppointment;
using Service.ServiceBlog;
using Service.ServiceDean;
using Service.ServiceMedicalDocumentation;
using Service.ServicePatient;
using Service.ServiceUser;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Main.ConsoleApplication
{
    public class PatientConsole
    {
        public List<Examination> PatientsExaminations { get; set; }
        public List<Operation> PatientsOperations { get; set; }
        public RegisteredPatient RegisteredPatient { get; set; }
        public Doctor Doctor { get; set; }
        public PatientChart PatientChart { get; set; }
        public RegisteredUserController RegisteredUserController { get; set; }
        public RegisteredPatientController RegisteredPatientController { get; set; }
        public UserController UserController { get; set; }

        public PatientConsole()
        {
            UserController = new UserController(new UserService(new RegisteredUserRepository(), new BlogArticlesRepository(), new QuestionsRepository(), new PersonRepository()));
            RegisteredUserController = new RegisteredUserController(new RegisteredUserService(new RegisteredUserRepository(), new FeedbackRepository()));
            RegisteredPatientController = new RegisteredPatientController(new RegisteredPatientService(new RegisteredPatientRepository(), new RegisteredUserRepository(), new PatientChartRepository()));
            ShowStartPage();
        }

        private void ShowStartPage()
        {
            bool Running = true;
            while (Running)
            {
                Console.WriteLine("Dobrodosli u konzolnu reprezentaciju pacijentovih funkcionalnosti! Za pocetak rada sa aplikacijom, odaberite opciju: ");
                Console.WriteLine("1 - Logovanje");
                Console.WriteLine("2 - Resetovanje lozinke");
                Console.WriteLine("3 - Registracija");
                Console.WriteLine("0 - Izlazak");
                int input=9;
                while (!Int32.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Unos mora biti ceo broj!");
                }
                switch (input)
                {
                    case 1:
                        signIn();
                        break;
                    case 2:
                        resetPassword();
                        break;
                    case 3:
                        register();
                        break;
                    case 0:
                        {
                            Running = false;
                        }
                        break;
                    default: break;
                }
            }

        }
        private void signIn()
        {
            RegisteredPatientController = new RegisteredPatientController(new RegisteredPatientService(new RegisteredPatientRepository(), new RegisteredUserRepository(), new PatientChartRepository()));
            PatientChartController patientChartController = new PatientChartController(new PatientChartService(new PatientChartRepository()));

            int k = 0;
            while (k == 0)
            {
                Console.WriteLine("Username: ");
                string username = Console.ReadLine();
                Console.WriteLine("Password: ");
                string password = Console.ReadLine();

                RegisteredUser registeredUser = RegisteredUserController.Login(new Account(username, password));
                if (registeredUser == null)
                {
                    Console.WriteLine("Logovanje nije uspesno! \n Molim Vas ponovite! \n");
                }
                else
                {
                    k = 1;
                    Console.WriteLine("Uspesno ste se ulogovali! \n");
                    printLogedInUser(registeredUser);
                    RegisteredPatient = RegisteredPatientController.Get(registeredUser.Pin);
                    PatientChart = patientChartController.GetPatientChartByPatient(RegisteredPatient);
                    PatientMainPage();
                }
            }
        }
        private void printLogedInUser(RegisteredUser registeredUser)
        {
            Console.WriteLine("Ime:   " + registeredUser.Name);
            Console.WriteLine("Ime roditelja:   " + registeredUser.ParentName);
            Console.WriteLine("Prezime:   " + registeredUser.Surname);
            Console.WriteLine("Datum rodjenja:   " + registeredUser.BirthDate.Date.ToString());
            Console.WriteLine("Grad rodjenja:   " + registeredUser.CityOfBirth.Name.ToString());
            Console.WriteLine("Adresa:   " + registeredUser.LivingLocation.Address.StreetName + " " + registeredUser.LivingLocation.Address.StreetNumber + ", " + registeredUser.LivingLocation.City.Name + ", " + registeredUser.LivingLocation.State.Name);
            Console.WriteLine("Broj telefona:   " + registeredUser.PhoneNumber);
            Console.WriteLine("Jmbg:   " + registeredUser.Pin);

        }
        private void resetPassword()
        {
            RegisteredUserController = new RegisteredUserController(new RegisteredUserService(new RegisteredUserRepository(), new FeedbackRepository()));
            while (true)
            {
                Console.WriteLine("Username: ");
                string username = Console.ReadLine();
                RegisteredUser registeredUser = RegisteredUserController.GetRegisteredUserByUsername(username);
                if (registeredUser == null)
                {
                    Console.WriteLine("Odabrani username ne postoji!");
                    Console.WriteLine("Molim Vas ponovite!");
                }
                else
                {
                    Console.WriteLine("Unesite novu lozinku:");
                    string password = Console.ReadLine();
                    RegisteredUserController.ChangePassword(password, registeredUser);
                    Console.WriteLine("Uspesno ste promenili lozinku!");
                    ShowStartPage();
                }
            }
        }
        private void register()
        {
            Console.WriteLine("Unesite ime: ");
            string name = Console.ReadLine();
            Console.WriteLine("--------------");

            Console.WriteLine("Unesite ime roditelja: ");
            string parentName = Console.ReadLine();
            Console.WriteLine("--------------");

            Console.WriteLine("Unesite prezime: ");
            string lastname = Console.ReadLine();
            Console.WriteLine("--------------");

            DateTime birthDate = chooseDate();
            Console.WriteLine("--------------");

            Console.WriteLine("Unesite JMBG: ");
            string pin = Console.ReadLine();
            Console.WriteLine("--------------");

            Console.WriteLine("Unesite broj telefona: ");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("--------------");

            Console.WriteLine("Unesite email: ");
            string email = Console.ReadLine();
            Console.WriteLine("--------------");

            Console.WriteLine("Unesite ime grada u kome ste se rodili: ");
            City cityOfBirth = chooseCity();
            Console.WriteLine("--------------");

            Location location = chooseLocation();
            Console.WriteLine("--------------");

            Account account = chooseAccount();
            Console.WriteLine("--------------");

            RegisteredUser registeredUser = UserController.SignUp(account, new Person(name, lastname, pin, birthDate, phoneNumber, email, parentName, cityOfBirth, location));
            if (registeredUser != null)
            {
                Console.WriteLine("Uspesno ste kreirali nalog!");
                Doctor chosenDoctor = chooseDefaultDoctor();
                if(RegisteredPatientController.ConvertRegisteredUserToRegisteredPatient(chosenDoctor, registeredUser))
                {
                    Console.WriteLine("Uspesno ste se registrovali");
                }
                
            }
            else
            {
                Console.WriteLine("Doslo je do neke greske!");
                Console.WriteLine("--------------");
            }
        }
        private Doctor chooseDefaultDoctor()
        {
            DoctorController doctorController = new DoctorController(new Service.ServiceDoctor.DoctorService(new DoctorRepository()));
            List<Doctor> doctors = doctorController.GetAllDoctors();
            Dictionary<int, string> doctorsDict = new Dictionary<int, string>();
            Console.WriteLine("Odaberite omiljenog lekara: ");
            for (int i = 0; i < doctors.Count; i++)
            {
                doctorsDict.Add(i, doctors[i].Pin);
                Console.WriteLine(i + " - " + doctors[i].Name + " " + doctors[i].Surname);
            }
            int input = -1;

            bool Running = true;
            while (Running)
            {
                try
                {
                    input = int.Parse(Console.ReadLine());

                    if (input >= 0 && input < doctors.Count)
                    {
                        Running = false;

                    }
                    else
                    {
                        Console.WriteLine("Unesite podesan broj");
                    }
                }
                catch
                {
                    Console.WriteLine("Nije dobar unos! Ponovite izbor!");
                }
            }


            Doctor doctor = doctorController.GetDoctorById(doctorsDict[input]);
            return doctor;
        }
        private Account chooseAccount()
        {
            RegisteredUserController = new RegisteredUserController(new RegisteredUserService(new RegisteredUserRepository(), new FeedbackRepository()));
            while (true)
            {
                Console.WriteLine("Unesite username: ");
                string username = Console.ReadLine();
                RegisteredUser registeredUser = RegisteredUserController.GetRegisteredUserByUsername(username);
                if (registeredUser != null)
                {
                    Console.WriteLine("Odabrani username je zauzet");
                    Console.WriteLine("Molim Vas ponovite!");
                }
                else
                {
                    Console.WriteLine("Unesite password:");
                    string password = Console.ReadLine();
                    Account account = new Account(username, password);
                    return account;
                }
            }
        }
        private Location chooseLocation()
        {
            Console.WriteLine("Unesite ime ulice: ");
            string streetName = Console.ReadLine();
            Console.WriteLine("Unesite broj ulice");
            int streetNum = 0;
            int k = 0;
            while (!Int32.TryParse(Console.ReadLine(), out streetNum))
                Console.WriteLine("Unos mora biti ceo broj!");


            Address address = new Address(streetName, streetNum);


            Console.WriteLine("Unesite ime grada u kome zivite: ");
            City city = chooseCity();
            Console.WriteLine("Unesite ime drzave: ");
            State state = new State(Console.ReadLine());

            return new Location(state, city, address);
        }

        private City chooseCity()
        {
            string cityName = Console.ReadLine();

            Console.WriteLine("Unesite postanski broj grada: ");
            int cityPin;
            while (!Int32.TryParse(Console.ReadLine(), out cityPin))
                Console.WriteLine("Unos mora biti ceo broj!");

            return new City(cityName,cityPin);
        }

        private DateTime chooseDate()
        {
            int year = chooseYear();
            int month = chooseMonth();
            int day = chooseDay(DateTime.DaysInMonth(year, month));
            return new DateTime(year, month, day);
        }

        private int chooseDay(int numberOfDaysInMonth)
        {
            Console.WriteLine("Unesite dan: ");
            while (true)
            {
                try
                {
                    int day = int.Parse(Console.ReadLine());
                    if (day <= numberOfDaysInMonth && day > 0)
                        return day;
                    else
                        Console.WriteLine("Nije dobar dan odabran! Ponovite unos!");
                }
                catch
                {
                    Console.WriteLine("Dan nije unet u dobrom formatu! Ponovite unos!");
                }
            }
        }
        private int chooseYear()
        {
            Console.WriteLine("Unesite godinu: ");
            while (true)
            {
                try
                {
                    int year = int.Parse(Console.ReadLine());
                    if (year <= 2020)
                        return year;
                    else
                        Console.WriteLine("Nije odabrana dobra godina! Ponovite unos!");
                }
                catch
                {
                    Console.WriteLine("Nije uspesno uneta godina! Ponovite unos!");
                }
            }
        }
        private int chooseMonth()
        {
            Dictionary<string, int> months = new Dictionary<string, int>();

            months.Add("Januar", 1);
            months.Add("Februar", 2);
            months.Add("Mart", 3);
            months.Add("April", 4);
            months.Add("Maj", 5);
            months.Add("Jun", 6);
            months.Add("Jul", 7);
            months.Add("Avgust", 8);
            months.Add("Septembar", 9);
            months.Add("Oktobar", 10);
            months.Add("Novembar", 11);
            months.Add("Decembar", 12);
            Console.WriteLine("Odaberite mesec: ");
            foreach (KeyValuePair<string, int> keyValuePair in months)
            {
                Console.WriteLine(keyValuePair.Key + " - " + keyValuePair.Value);
            }

            while (true)
            {
                try
                {
                    int month = int.Parse(Console.ReadLine());

                    if (!months.Values.Contains(month))
                        Console.WriteLine("Niste odabrali dobar mesec! Ponovite izbor!");
                    else
                        return month;
                }
                catch
                {
                    Console.WriteLine("Nije dobar unos! Ponovite izbor!");
                }

            }
        }
        private void PatientMainPage()
        {
            bool Running = true;
            while (Running)
            {
                Console.WriteLine("Odaberite opciju: ");
                Console.WriteLine("1 - Pristup blogu");
                Console.WriteLine("2 - Ocenjivanje rada lekara");
                Console.WriteLine("3 - Ostavljanje utiska o aplikaciji");
                Console.WriteLine("4 - Citanje notifikacija");
                Console.WriteLine("5 - Prikaz podataka profila");
                Console.WriteLine("6 - Zamena odabranog lekara");
                Console.WriteLine("7 - Izmena podataka na profilu");
                Console.WriteLine("8 - Pregled kartona");
                Console.WriteLine("9 - Istorijat bolesti");
                Console.WriteLine("10 - Zakazivanje hitnog pregleda");
                Console.WriteLine("11 - Prikaz zakazanih pregleda");
                Console.WriteLine("12 - Zakazivanje pregleda");
                Console.WriteLine("13 - Pomeri pregled");
                Console.WriteLine("14 - Preporuka pregleda");
                int input;
                while (!Int32.TryParse(Console.ReadLine(), out input))
                    Console.WriteLine("Unos mora biti ceo broj!");
                switch (input)
                {
                    case 1:
                        showBlog();
                        break;
                    case 2:
                        ratings();
                        break;
                    case 3:
                        leaveFeedback();
                        break;
                    case 4:
                        seeAllNotifications();
                        break;
                    case 5:
                        showProfile();
                        break;
                    case 6:
                        changeDefaultDoctor();
                        break;
                    case 7:
                        changeUserData();
                        break;
                    case 8:
                        seePatientChart();
                        break;
                    case 9:
                        seeDiseaseHistory();
                        break;
                    case 10:
                        requestEmergencyExam();
                        break;
                    case 11:
                        showPatientsScheduledExams();
                        break;
                    case 12:
                        scheduleExam();
                        break;
                    case 13:
                        rescheduleExam();
                        break;
                    case 14:
                        suggestExam();
                        break;
                    default:
                        Running = false;
                        break;
                }
            }

        }
        private void suggestExam()
        {
            DoctorController doctorController = new DoctorController(new Service.ServiceDoctor.DoctorService(new DoctorRepository()));
            AppointmentController appointmentController = new AppointmentController(new AppointmentService(new OperationRepository(), new ExaminationRepository(), new DoctorRepository()));
            ExaminationController examinationController = new ExaminationController(new ExaminationService(new ExaminationRepository(), new OperationRepository(), new DoctorRepository()));

            List<Doctor> doctors = doctorController.GetAllDoctorsGeneralMedicine();
            Console.WriteLine(doctors.Count);
            Dictionary<int, string> doctorsDict = new Dictionary<int, string>();

            Console.WriteLine("Odaberite lekara: ");
            for (int i = 0; i < doctors.Count; i++)
            {
                doctorsDict.Add(i, doctors[i].Pin);
                Console.WriteLine(i + " - " + doctors[i].Name + " " + doctors[i].Surname);
            }
            int input = -1;
            bool Running = true;
            while (Running)
            {
                try
                {
                    input = int.Parse(Console.ReadLine());
                    if (input >= 0 && input < doctors.Count)
                        Running = false;
                    else
                        Console.WriteLine("Unesite podesan broj");
                }
                catch
                {
                    Console.WriteLine("Nije dobar unos! Ponovite izbor!");
                }
            }
            Doctor doctor = doctorController.GetDoctorById(doctorsDict[input]);


            Console.WriteLine("Odaberite datum za pocetak perioda: ");

            DateTime startPeriod = chooseDateForExam();

            DateTime endPeriod = chooseEndPeriod(startPeriod);

            Examination exam = examinationController.SuggestExam(startPeriod, endPeriod, doctor, RegisteredPatient);
            if (exam != null)
            {
                printExam(exam);
                Console.WriteLine("Odaberite 1 za zakazivanje pregleda, 0 za izlazak");
                
                while (!Int32.TryParse(Console.ReadLine(), out input))
                    Console.WriteLine("Unos mora biti ceo broj!");
                switch (input)
                {
                    case 1:
                        {
                            if(examinationController.ScheduleExam(exam))
                                Console.WriteLine("Uspesno ste zakazali pregled");
                            else
                                Console.WriteLine("Doslo je do neke greske");
                            break;                        
                        }
                    case 0:
                        {
                            Console.WriteLine("Hvala sto ste koristili vizard za preporuku! Ukoliko vam se ne dopada pregled, pokusajte opet!");
                            break;
                        }
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Odaberite sta vam je priortet! 1 - Doktor, 2 - Vremenski interval");
                while (!Int32.TryParse(Console.ReadLine(), out input))
                    Console.WriteLine("Unos mora biti ceo broj!");
                switch (input)
                {
                    case 1:
                        {
                            Examination examAsap = examinationController.GetDoctorsAppointmentASAP(doctor, RegisteredPatient);
                            if (examAsap != null)
                            {
                                printExam(examAsap);
                                Console.WriteLine("Odaberite 1 za zakazivanje pregleda, 0 za izlazak");

                                while (!Int32.TryParse(Console.ReadLine(), out input))
                                    Console.WriteLine("Unos mora biti ceo broj!");
                                switch (input)
                                {
                                    case 1:
                                        {
                                            if (examinationController.ScheduleExam(exam))
                                                Console.WriteLine("Uspesno ste zakazali pregled");
                                            else
                                                Console.WriteLine("Doslo je do neke greske");
                                            break;
                                        }
                                    case 0:
                                        {
                                            Console.WriteLine("Hvala sto ste koristili vizard za preporuku! Ukoliko vam se ne dopada pregled, pokusajte opet!");
                                            break;
                                        }
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Zao nam je, za zeljenog lekara ne postoje slobodni termini u narednom periodu....");
                            }
                            break;
                        }
                    case 2:
                        {
                            foreach(Doctor anyDoctor in doctors)
                            {
                                Examination anyExam = examinationController.SuggestExam(startPeriod, endPeriod, doctor, RegisteredPatient);
                                if (anyExam != null)
                                {
                                    printExam(anyExam);
                                    Console.WriteLine("Odaberite 1 za zakazivanje pregleda, 0 za izlazak");

                                    while (!Int32.TryParse(Console.ReadLine(), out input))
                                        Console.WriteLine("Unos mora biti ceo broj!");
                                    switch (input)
                                    {
                                        case 1:
                                            {
                                                if (examinationController.ScheduleExam(anyExam))
                                                {
                                                    Console.WriteLine("Uspesno ste zakazali pregled");
                                                    return;
                                                }
                                                else
                                                    Console.WriteLine("Doslo je do neke greske");
                                                break;
                                            }
                                        case 0:
                                            {
                                                Console.WriteLine("Hvala sto ste koristili vizard za preporuku! Ukoliko vam se ne dopada pregled, pokusajte opet!");
                                                break;
                                            }
                                        default:
                                            break;
                                    }
                                }
                            }
                            Console.WriteLine("Nazalost nismo nasli pregled za vas u ovom periodu...");
                            break;
                        }
                    default:
                        break;
                }
            }



        }
        private DateTime chooseEndPeriod(DateTime startDate)
        {
            Dictionary<string, int> months = new Dictionary<string, int>();

            months.Add("Januar", 1);
            months.Add("Februar", 2);
            months.Add("Mart", 3);
            months.Add("April", 4);
            months.Add("Maj", 5);
            months.Add("Jun", 6);
            months.Add("Jul", 7);
            months.Add("Avgust", 8);
            months.Add("Septembar", 9);
            months.Add("Oktobar", 10);
            months.Add("Novembar", 11);
            months.Add("Decembar", 12);
            Console.WriteLine("Odaberite mesec: ");
            Dictionary<string, int> allowedMonths = new Dictionary<string, int>();
            int currentMonth = DateTime.Now.Month;

            foreach (KeyValuePair<string, int> keyValuePair in months)
            {
                if (keyValuePair.Value >= startDate.Month)
                    Console.WriteLine(keyValuePair.Key + " - " + keyValuePair.Value);
            }
            int month = -1;
            bool Running = true;

            while (Running)
            {
                try
                {
                    month = int.Parse(Console.ReadLine());

                    if (!months.Values.Contains(month))
                        Console.WriteLine("Niste odabrali dobar mesec! Ponovite izbor!");
                    else
                        Running = false;
                }
                catch
                {
                    Console.WriteLine("Nije dobar unos! Ponovite izbor!");
                }

            }


            int day = -1;
            Console.WriteLine("Unesite dan: ");
            Running = true;
            while (Running)
            {
                try
                {
                    day = int.Parse(Console.ReadLine());
                    if (day <= DateTime.DaysInMonth(2020, month) && new DateTime(2020, month, day) > startDate)
                        Running = false;
                    else
                        Console.WriteLine("Nije dobar dan odabran! Ponovite unos!");
                }
                catch
                {
                    Console.WriteLine("Dan nije unet u dobrom formatu! Ponovite unos!");
                }
            }


            return new DateTime(2020,month,day);
        }
        private void rescheduleExam()
        {
            AppointmentController appointmentController = new AppointmentController(new AppointmentService(new OperationRepository(), new ExaminationRepository(), new DoctorRepository()));
            ExaminationController examinationController = new ExaminationController(new ExaminationService(new ExaminationRepository(),new OperationRepository(), new DoctorRepository()));
            DoctorController doctorController = new DoctorController(new Service.ServiceDoctor.DoctorService(new DoctorRepository()));


            Console.WriteLine("Odaberite pregleda za pomeranje");
            Dictionary<int, Examination> dictionaryExaminations = new Dictionary<int, Examination>();
            int counter = 0;
            foreach (Examination exam in examinationController.GetAllPatientsExams(RegisteredPatient))
            {
                Console.WriteLine(counter);
                printExam(exam);
                dictionaryExaminations.Add(counter, exam);
                counter++;
            }
            int input = -1;
            bool Running = true;
            while (Running)
            {
                try
                {
                    input = int.Parse(Console.ReadLine());

                    if (!dictionaryExaminations.Keys.Contains(input))
                        Console.WriteLine("Niste odabrali dobar mesec! Ponovite izbor!");
                    else
                        Running = false;
                }
                catch
                {
                    Console.WriteLine("Nije dobar unos! Ponovite izbor!");
                }
            }

            Examination examination = dictionaryExaminations[input];
            printExam(examination);

            Console.WriteLine("Odaberite novi termin pregleda: ");

            DateTime newDateForExamination = chooseDateForExam();
            List<Term> freeTermsForDate = appointmentController.GetAllDoctorsFreeTermsForDate(doctorController.GetDoctorById(examination.Doctor.Pin), newDateForExamination);
            if (freeTermsForDate == null)
            {
                Console.WriteLine("Za odabrani datum nema slobodnih termina");
            }
            else
            {
                Dictionary<int, Term> termsDict = new Dictionary<int, Term>();

                for (int termCounter = 0; termCounter < freeTermsForDate.Count; termCounter++)
                {
                    Console.WriteLine(termCounter + " - " + freeTermsForDate[termCounter].Start);
                    Console.WriteLine("----");
                    termsDict.Add(termCounter, freeTermsForDate[termCounter]);
                }

                input = -1;
                Running = true;
                while (Running)
                {
                    try
                    {
                        input = int.Parse(Console.ReadLine());
         
                        if (input >= 0 && input < freeTermsForDate.Count)
                            Running = false;
                        else
                            Console.WriteLine("Unesite podesan broj");
                    }
                    catch
                    {
                        Console.WriteLine("Nije dobar unos! Ponovite izbor!");
                    }
                }

                Term examTerm = termsDict[input];

                //Examination rescheduledExam = new Examination(examRoom, false, randomId.RandomString, AppointmentType.EXAMINATION, RegisteredPatient, examTerm, doctor, examDate);
                examination.Term = examTerm;
                examination.Date = newDateForExamination;
                if (examinationController.RescheduleExam(examination))
                {
                    Console.WriteLine("Uspesno ste pomerili pregled!");
                }
            }
        }
        private DateTime chooseDateForExam()
        {
            int month = chooseMonthForExam();
            int day = chooseDayForExam(month);
            return new DateTime(2020, month, day);
        }
        private int chooseMonthForExam()
        {
            Dictionary<int, string> months = new Dictionary<int, string>();

            months.Add(1, "Januar");
            months.Add(2,"Februar");
            months.Add(3,"Mart");
            months.Add(4,"April");
            months.Add(5,"Maj");
            months.Add(6,"Jun");
            months.Add(7,"Jul");
            months.Add(8,"Avgust");
            months.Add(9,"Septembar");
            months.Add(10,"Oktobar");
            months.Add(11,"Novembar");
            months.Add(12, "Decembar");
            Console.WriteLine("Odaberite mesec: ");
            Dictionary<int, string> allowedMonths = new Dictionary<int, string>();
            int currentMonth = DateTime.Now.Month;

            foreach (KeyValuePair<int,string> keyValuePair in months)
            {
                if(keyValuePair.Key >= currentMonth)
                {
                    Console.WriteLine(keyValuePair.Key + " - " + keyValuePair.Value);
                    allowedMonths.Add(keyValuePair.Key, keyValuePair.Value);
                }

            }

            while (true)
            {
                try
                {
                    int month = int.Parse(Console.ReadLine());

                    if (!allowedMonths.Keys.Contains(month))
                        Console.WriteLine("Niste odabrali dobar mesec! Ponovite izbor!");
                    else
                        return month;
                }
                catch
                {
                    Console.WriteLine("Nije dobar unos! Ponovite izbor!");
                }

            }

        }
        private int chooseDayForExam(int month)
        {
            int numberOfDaysInMonth = DateTime.DaysInMonth(2020,month);
            Console.WriteLine("Unesite dan: ");
            while (true)
            {
                try
                {
                    int day = int.Parse(Console.ReadLine());
                    if (day <= numberOfDaysInMonth && new DateTime(2020,month,day) > DateTime.Today.Date)
                        return day;
                    else
                        Console.WriteLine("Nije dobar dan odabran! Ponovite unos!");
                }
                catch
                {
                    Console.WriteLine("Dan nije unet u dobrom formatu! Ponovite unos!");
                }
            }
        }
        private void scheduleExam()
        {
            DoctorController doctorController = new DoctorController(new Service.ServiceDoctor.DoctorService(new DoctorRepository()));
            AppointmentController appointmentController = new AppointmentController(new AppointmentService(new OperationRepository(), new ExaminationRepository(), new DoctorRepository()));
            ExaminationController examinationController = new ExaminationController(new ExaminationService(new ExaminationRepository(), new OperationRepository(), new DoctorRepository()));

            List<Doctor> doctors = doctorController.GetAllDoctorsGeneralMedicine();
            Console.WriteLine(doctors.Count);
            Dictionary<int, string> doctorsDict = new Dictionary<int, string>();

            Console.WriteLine("Odaberite lekara: ");
            for (int i = 0; i < doctors.Count; i++)
            {
                doctorsDict.Add(i, doctors[i].Pin);
                Console.WriteLine(i + " - " + doctors[i].Name + " " + doctors[i].Surname);
            }
            int input = -1;
            bool Running = true;
            while (Running)
            {
                try
                {
                    input = int.Parse(Console.ReadLine());
                    if (input >= 0 && input < doctors.Count)
                        Running = false;
                    else
                        Console.WriteLine("Unesite podesan broj");
                }
                catch
                {
                    Console.WriteLine("Nije dobar unos! Ponovite izbor!");
                }
            }
            Doctor doctor = doctorController.GetDoctorById(doctorsDict[input]);
            Console.WriteLine("Odaberite datum za pregled!");
            DateTime examDate = chooseDateForExam();
            List<Term> freeTermsForDate = appointmentController.GetAllDoctorsFreeTermsForDate(doctor, examDate);
            if (freeTermsForDate == null)
            {
                Console.WriteLine("Za odabrani datum nema slobodnih termina");
            }
            else
            {
                Dictionary<int, Term> termsDict = new Dictionary<int, Term>();

                for (int counter = 0; counter<freeTermsForDate.Count;counter++)
                {
                    Console.WriteLine(counter + " - " + freeTermsForDate[counter].Start);
                    Console.WriteLine("----");
                    termsDict.Add(counter, freeTermsForDate[counter]);
                }

                input = -1;
                Running = true;
                while (Running)
                {
                    try
                    {
                        input = int.Parse(Console.ReadLine());
                        if (input >= 0 && input < freeTermsForDate.Count)
                            Running = false;
                        else
                            Console.WriteLine("Unesite podesan broj");
                    }
                    catch
                    {
                        Console.WriteLine("Nije dobar unos! Ponovite izbor!");
                    }
                }

                Term examTerm = termsDict[input];

                RandomStringGenerator randomId = new RandomStringGenerator(9);
                while (examinationController.GetExamById(randomId.RandomString) != null)
                {
                    randomId = new RandomStringGenerator(9);
                }

                Room examRoom = Program.examRoomController.GetExamRoomById(doctor.DefaultExamRoom.Id);

                Examination examination = new Examination(examRoom, false, randomId.RandomString, AppointmentType.EXAMINATION, RegisteredPatient, examTerm, doctor, examDate);
                if (examinationController.ScheduleExam(examination))
                {
                    Console.WriteLine("Uspesno ste zakazali pregled!");
                }
               
            }
        }
        private void showPatientsScheduledExams()
        {
            ExaminationController examinationController = new ExaminationController(new ExaminationService(new ExaminationRepository(), new OperationRepository(), new DoctorRepository()));
            foreach(Examination exam in examinationController.GetAllPatientsExams(RegisteredPatient))
            {
                printExam(exam);
            }
        }
        private void printExam(Examination exam)
        {
            DoctorController doctorController = new DoctorController(new Service.ServiceDoctor.DoctorService(new DoctorRepository()));
            Console.WriteLine("Broj sobe za pregled: " + Program.examRoomController.GetExamRoomById(exam.ExamRoom.Id).Name);
            Console.WriteLine("Doktor: "+ doctorController.GetDoctorById(exam.Doctor.Pin).Name +" "+  doctorController.GetDoctorById(exam.Doctor.Pin).Surname);
            Console.WriteLine("Termin: " + exam.Term.Start);
            Console.WriteLine("--------------------------");
        }
        private void seeAllNotifications()
        {
            NotificationController notificationController = new NotificationController(new NotificationService(new NotificationRepository()));
            foreach(Notification notification in notificationController.GetAllUsersNotifications(RegisteredPatient.Pin))
            {
                Console.WriteLine("Datum kreiranja notifikacije: " + notification.DateOfCreation);
                if (notification.IsEmergencyAppointment.Equals(NotificationType.EMERGENCY_RESPONSE)) { Console.WriteLine("Odobren vam je termin za hitan pregled! "); }
                Console.WriteLine(notification.Text);
                Console.WriteLine("--------------");

            }
        }
        private void requestEmergencyExam()
        {
            NotificationController notificationController = new NotificationController(new NotificationService(new NotificationRepository()));
            RandomStringGenerator randomId = new RandomStringGenerator(7);
            while (notificationController.GetNotification(randomId.RandomString) != null)
            {
                randomId = new RandomStringGenerator(7);
            }

            Notification emergencyNotification = new Notification(RegisteredPatient.Pin, randomId.RandomString, "ZAHTEV ZA HITAN PREGLED", DateTime.Now, NotificationType.EMERGENCY_REQUEST);

            if (notificationController.MakeRequestForEmergencyAppointment(emergencyNotification))
                Console.WriteLine("Poslali ste zahtev za hitan pregled!");
            else
                Console.WriteLine("Doslo je do neke greske!");
        }
        private void seeDiseaseHistory()
        {
            ReportOfExaminationController reportOfExaminationController = new ReportOfExaminationController(new ReportOfExaminationService(new ReportOfExaminationRepository()));
            Console.WriteLine("Istorijat bolesti:");
            foreach(ReportOfExamination reportOfExamination in reportOfExaminationController.GetAllReportOfExaminationByPatientChart(PatientChart))
            {
                Console.WriteLine("Datum: " + reportOfExamination.Date);
                Console.WriteLine("Simptomi: "+reportOfExamination.Symptom);
                Console.WriteLine("Dijagnoza: " + reportOfExamination.Diagnosis);
                Console.WriteLine("Misljenje lekara: " + reportOfExamination.Opinion);
                Console.WriteLine("--------------");
            }
        }
        private void seePatientChart()
        {
        
            PrescriptionController prescriptionController = new PrescriptionController(new PrescriptionService(new PrescriptionRepository()));

            DrugController drugController = new DrugController(new DrugServices(new DrugRepository()));
            TherapyController therapyController = new TherapyController(new TherapyService(new TherapyRepository()));
            Console.WriteLine("-----Prikaz kartona-----");
            Console.WriteLine("Alergije: ");
            foreach(Allergy allergy in PatientChart.Allergies)
            {
                Console.WriteLine(allergy.Name);
            }
            Console.WriteLine("--------------");

            
            foreach (Prescription prescription in prescriptionController.GetAllPrescriptionsByPatientChart(PatientChart)){
                Console.WriteLine("Datum prepisivanja leka: " + prescription.Date);
                Console.WriteLine("Lek: " + drugController.Get(prescription.Drug.Id).Name);
                //Console.WriteLine("Proizvodjac leka: "+ drugController.GetItem(prescription.Drug.Id).DrugProducer);
                Console.WriteLine("Opis: "+prescription.Description);
            }
            

            foreach (Therapy therapy in therapyController.GetAllTherapiesByPatientChart(PatientChart))
            {
                Console.WriteLine("Datum izdavanja terapije: "+therapy.Date);
                printPrescribedDrug(therapy);
                Console.WriteLine("--------------");

            }

        }
        private void printPrescribedDrug(Therapy therapy)
        {
            DrugController drugController = new DrugController(new DrugServices(new DrugRepository()));

            foreach (PrescribedDrug prescribedDrug in therapy.PrescribedDrugs)
            {
                Console.WriteLine("Prepisan lek: " + drugController.Get(prescribedDrug.Drug.Id).Name);
                Console.WriteLine("Dnevna doza: " +  prescribedDrug.DailyDose);
                Console.WriteLine("Pocetak uzimanja leka: " + prescribedDrug.StartDate);
                Console.WriteLine("Kraj uzimanja leka: " + prescribedDrug.EndDate);

            }
        }
        private void leaveFeedback()
        {
            RandomStringGenerator randomId = new RandomStringGenerator(8);
            while (RegisteredUserController.GetFeedback(randomId.RandomString) != null)
            {
                randomId = new RandomStringGenerator(8);
            }
            Console.WriteLine("Unesite vas utisak o aplikaciji:");
            string feedbackText = Console.ReadLine();
            if(RegisteredUserController.PostFeedback(new Feedback(RegisteredPatient, randomId.RandomString, feedbackText, DateTime.Now)))
            {
                Console.WriteLine("Uspesno!");
            }
            else
            {
                Console.WriteLine("Doslo je do greske neke idk man!");
            }

        }
        private void changeUserData()
        {
            printLogedInUser(RegisteredPatient);
            Console.WriteLine("Odaberite opciju za promenu");
            Console.WriteLine("1 - Promena imena");
            Console.WriteLine("2 - Promena imena roditelja");
            Console.WriteLine("3 - Promena prezimena");
            Console.WriteLine("4 - Promena datuma rodjenja");
            Console.WriteLine("5 - Promena grada rodjenja");
            Console.WriteLine("6 - Promena adrese stanovanja");
            Console.WriteLine("7 - Promena broja telefona");
            int input=0;
            bool Running = true;
            while (Running)
            {
                try
                {
                    input = int.Parse(Console.ReadLine());

                    if (input >= 0 && input < 8)
                    {
                        Running = false;
                    }
                    else
                    {
                        Console.WriteLine("Unesite podesan broj");
                    }
                }
                catch
                {
                    Console.WriteLine("Nije dobar unos! Ponovite izbor!");
                }
            }

            switch (input)
            {
                case 1:
                    {
                        Console.WriteLine("Unesite novo ime: ");
                        string newName = Console.ReadLine();
                        RegisteredPatient.Name = newName;
                        RegisteredPatientController.EditRegisteredPatient(RegisteredPatient);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Unesite novo ime roditelja: ");
                        string newParentName = Console.ReadLine();
                        RegisteredPatient.ParentName = newParentName;
                        RegisteredPatientController.EditRegisteredPatient(RegisteredPatient); 
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Unesite novo prezime: ");
                        string newLastname = Console.ReadLine();
                        RegisteredPatient.Surname = newLastname;
                        RegisteredPatientController.EditRegisteredPatient(RegisteredPatient);
                        break;
                    }
                case 4:
                    {
                        DateTime newBirthDate = chooseDate();
                        RegisteredPatient.BirthDate = newBirthDate;
                        RegisteredPatientController.EditRegisteredPatient(RegisteredPatient);
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("Unesite ime grada u kome ste se rodili");
                        City newBirthCity = chooseCity();
                        RegisteredPatient.CityOfBirth = newBirthCity;
                        RegisteredPatientController.EditRegisteredPatient(RegisteredPatient);
                        break;
                    }
                case 6:
                    {
                        Location newLocation = chooseLocation();
                        RegisteredPatient.LivingLocation = newLocation;
                        RegisteredPatientController.EditRegisteredPatient(RegisteredPatient);
                        break;
                    }
                case 7:
                    {
                        Console.WriteLine("Unesite novi broj telefona");
                        string newPhoneNumber = Console.ReadLine();
                        RegisteredPatient.PhoneNumber = newPhoneNumber;
                        RegisteredPatientController.EditRegisteredPatient(RegisteredPatient);
                        break;
                    }
                default:
                    break;
            }

        }
        private void changeDefaultDoctor()
        {
            DoctorController doctorController = new DoctorController(new Service.ServiceDoctor.DoctorService(new DoctorRepository()));

            Console.WriteLine("Trenutni odabrani lekar je: "+ doctorController.GetDoctorById(RegisteredPatient.ChosenDoctor.Pin).Name + " " + doctorController.GetDoctorById(RegisteredPatient.ChosenDoctor.Pin).Surname);
            
            List<Doctor> doctors = doctorController.GetAllDoctors();
            Dictionary<int, string> doctorsDict = new Dictionary<int, string>();
            Console.WriteLine("Odaberite novog lekara: ");
            for (int i = 0; i < doctors.Count; i++)
            {
                doctorsDict.Add(i, doctors[i].Pin);
                Console.WriteLine(i + " - " + doctors[i].Name + " " + doctors[i].Surname);
            }
            int input = -1;

            bool Running = true;
            while (Running)
            {
                try
                {
                    input = int.Parse(Console.ReadLine());

                    if (input >= 0 && input < doctors.Count)
                    {
                        Running = false;
                    }
                    else
                    {
                        Console.WriteLine("Unesite podesan broj");
                    }
                }
                catch
                {
                    Console.WriteLine("Nije dobar unos! Ponovite izbor!");
                }
            }


            Doctor doctor = doctorController.GetDoctorById(doctorsDict[input]);
            Console.WriteLine("doktor: " + doctor.Name+ " " + doctor.Surname );

            RegisteredPatientController.ChangeChosenDoctor(doctor, RegisteredPatient);
            string patientId = RegisteredPatient.Pin;
            RegisteredPatient = RegisteredPatientController.Get(patientId);
            Console.WriteLine(doctorController.GetDoctorById(RegisteredPatient.ChosenDoctor.Pin).Name);
        }

        private void showProfile()
        {
            DoctorController doctorController = new DoctorController(new Service.ServiceDoctor.DoctorService(new DoctorRepository()));

            printLogedInUser(RegisteredPatient);
            Console.WriteLine("Odabrani lekar: " + doctorController.GetDoctorById(RegisteredPatient.ChosenDoctor.Pin).Name + " " + doctorController.GetDoctorById(RegisteredPatient.ChosenDoctor.Pin).Surname);
            
        }
        private void rateDoctor()
        {
            DoctorController doctorController = new DoctorController(new Service.ServiceDoctor.DoctorService(new DoctorRepository()));
            List<Doctor> doctors = doctorController.GetAllDoctors();
            Dictionary<int, string> doctorsDict = new Dictionary<int, string>();
            Console.WriteLine("Odaberite lekara za ocenu: ");
            for(int i = 0; i < doctors.Count; i++)
            {
                doctorsDict.Add(i, doctors[i].Pin);
                Console.WriteLine(i+" - " + doctors[i].Name + " " + doctors[i].Surname);
            }
            int input=-1;

            bool Running = true;

            Running = true;
            while (Running)
            {
                try
                {
                    input = int.Parse(Console.ReadLine());

                    if (input >= 0 && input < doctors.Count)
                    {
                        Running = false;
                    }
                    else
                    {
                        Console.WriteLine("Unesite podesan broj");
                    }
                }
                catch
                {
                    Console.WriteLine("Nije dobar unos! Ponovite izbor!");
                }
            }


            Doctor doctor = doctorController.GetDoctorById(doctorsDict[input]);
            Console.WriteLine("Odaberite ocenu: ");
            Console.WriteLine("1 - "+ RatingValue.one);
            Console.WriteLine("2 - "+RatingValue.two);
            Console.WriteLine("3 - "+RatingValue.three);
            Console.WriteLine("4 - "+RatingValue.four);
            Console.WriteLine("5 - "+RatingValue.five);
            int rate=99999;
            RatingValue rateVal = new RatingValue();
            Running = true;
            while (Running)
            {
                try
                {
                    rate = int.Parse(Console.ReadLine());

                    if (rate >= 1 && rate <= 5)
                        Running = false;
                    else
                        Console.WriteLine("Niste odabrali dobru ocenu! Ponovite izbor!");
                }
                catch
                {
                    Console.WriteLine("Nije dobar unos! Ponovite izbor!");
                }
            }
            

            switch (rate)
            {
                case 1:
                    rateVal = RatingValue.one;
                    break;
                case 2:
                    rateVal = RatingValue.two;
                    break;
                case 3:
                    rateVal = RatingValue.three;
                    break;
                case 4:
                    rateVal = RatingValue.four;
                    break;
                case 5:
                    rateVal = RatingValue.five;
                    break;
                default:
                    break;
            }
            Console.WriteLine("Unesite tekst ocene:");
            string ratingText = Console.ReadLine();
            RatingsController ratingsController = new RatingsController(new RatingsService(new RatingsRepository()));
            RandomStringGenerator randomId = new RandomStringGenerator(7);
            while (ratingsController.GetRatingById(randomId.RandomString) != null)
            {
                randomId = new RandomStringGenerator(7);
            }
            Rating rating = new Rating(randomId.RandomString, rateVal, ratingText, doctor, RegisteredPatient);
            if (ratingsController.RateDoctor(rating))
            {
                Console.WriteLine("Uspesno ste ocenili lekara!");
            }
            else
            {
                Console.WriteLine("Doslo je do neke greske!");
            }
        }


        private void showPatientsRatings()
        {
            RatingsController ratingsController = new RatingsController(new RatingsService(new RatingsRepository()));
            DoctorController doctorController = new DoctorController(new Service.ServiceDoctor.DoctorService(new DoctorRepository()));

            foreach (Rating rating in ratingsController.GetAllPatientsRatings(RegisteredPatient))
            {
                Console.WriteLine("Doktor: " + doctorController.GetDoctorById(rating.Doctor.Pin).Name + " " + doctorController.GetDoctorById(rating.Doctor.Pin).Surname);
                Console.WriteLine("Ocena: " + rating.Rate.ToString());
            }
        }
        private void ratings()
        {
            bool Running = true;
            while (Running)
            {
                Console.WriteLine("Odaberite opciju: ");
                Console.WriteLine("1 - Pirkaz vasih ocena");
                Console.WriteLine("2 - Ocenite rad lekara");
                           int input;
                while (!Int32.TryParse(Console.ReadLine(), out input))
                    Console.WriteLine("Unos mora biti ceo broj!");
                switch (input)
                {
                    case 1:
                        showPatientsRatings();
                        break;
                    case 2:
                        rateDoctor();
                        break;
                    default:
                        Running = false;
                        break;
                }
            }
        }
        private void showBlog()
        {
            bool Running = true;
            while (Running)
            {
                Blog blog = UserController.ShowBlog();
                Console.WriteLine("Odaberite opciju: ");
                Console.WriteLine("1 - Citanje bloga");
                Console.WriteLine("2 - Citanje pitanja i odgovora");
                Console.WriteLine("3 - Postavljanje pitanja");
                int input;
                while (!Int32.TryParse(Console.ReadLine(), out input))
                    Console.WriteLine("Unos mora biti ceo broj!");
                switch (input)
                {
                    case 1:
                        blogArticles(blog);
                        break;
                    case 2:
                        qAndA(blog);
                        break;
                    case 3:
                        askQuestion();
                        break;
                    default:
                        {
                            Running = false;
                            PatientMainPage();
                            break;
                        }
                        
                }
            }
            
        }
        private void qAndA(Blog blog)
        {
            RegisteredUserController = new RegisteredUserController(new RegisteredUserService(new RegisteredUserRepository(), new FeedbackRepository()));
            DoctorController doctorController = new DoctorController(new Service.ServiceDoctor.DoctorService(new DoctorRepository()));

            foreach (Question question in blog.QandA.Questions)
            {
                Console.WriteLine("Naslov pitanja: " + question.Title);
                Console.WriteLine("Datum  objave: " + question.DateOfCreation.ToLocalTime());
                RegisteredPatient registeredPatient = RegisteredPatientController.Get(question.RegisteredPatient.Pin);
                Console.WriteLine("Autor pitanja: " + registeredPatient.Name + " " + registeredPatient.Surname);
                Console.WriteLine("Pitanje: " + question.Text);
                if (question.Answered)
                {
                    Console.WriteLine("Odgovor: " + question.Answer.Text);
                    Console.WriteLine("Autor odgovora: " + doctorController.GetDoctorById(question.Answer.Doctor.Pin).Name + " " + doctorController.GetDoctorById(question.Answer.Doctor.Pin).Surname);
                }
                Console.WriteLine("------------------------------------------------------------------");
            }
        }



        private void askQuestion()
        {
            QuestionController questionController = new QuestionController(new QuestionService(new QuestionsRepository()));

            RandomStringGenerator randomId = new RandomStringGenerator(7);
            while (questionController.GetQuestionById(randomId.RandomString) != null)
            {
                randomId = new RandomStringGenerator(7);
            }
            //Console.WriteLine(randomId.RandomString);
            Console.WriteLine("Unesite naslov pitanja: ");
            string questionTitle = Console.ReadLine();
            Console.WriteLine("Unesite tekst pitanja: ");
            string questionText = Console.ReadLine();

            Question question = new Question(questionTitle, RegisteredPatient, randomId.RandomString, questionText, DateTime.Now);

            if (!questionController.AskQuestion(question))
            {
                Console.WriteLine("Doslo je do neke greske u postavljanju pitanja");
            }
            Console.WriteLine("Uspesno ste postavili pitanje!");

        }
        
            
        private void blogArticles(Blog blog)
        {
            DoctorController doctorController = new DoctorController(new Service.ServiceDoctor.DoctorService(new DoctorRepository()));

            foreach (BlogArticle blogArticle in blog.BlogArticles)
            {
                Console.WriteLine("Naslov clanka: " + blogArticle.Title);
                Doctor doctor = doctorController.GetDoctorById(blogArticle.Doctor.Pin);
                Console.WriteLine("Autor  clanka: " + doctor.Name + " " + doctor.Surname);
                Console.WriteLine("Datum  objave: " + blogArticle.DateOfCreation.Date.ToLocalTime());
                Console.WriteLine(blogArticle.Text);
                Console.WriteLine("------------------------------------------------------------------");
            }
        }
    }
}
