﻿using PersonPage.DbLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonPage
{
    public class MainDataContext : INotifyPropertyChanged, IDataErrorInfo
    {
        private string name = "";
        private int age = 1;
        private SexType sex = SexType.Men;
        private string imageLink = "Image\\User.png";

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                Notify(nameof(Name));
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
                Notify(nameof(Age));
            }
        }

        public SexType Sex
        {
            get
            {
                return sex;
            }
            set
            {
                sex = value;
                Notify(nameof(Sex));
            }
        }

        public string ImageLink
        {
            get
            {
                return imageLink;
            }
            set
            {
                imageLink = value;
                Notify(nameof(ImageLink));
            }
        }

        public string Validation1()
        {
            if (String.IsNullOrEmpty(Name))
            {
                return "Пожалуйста, введите ваше имя";
            }
            if (Name.Length <= 5)
            {
                return "Слишком корокое имя";
            }
            if (Name.Length > 35)
            {
                return "Слишком длинное имя";
            }
            return "";
        }
        public string Validation2()
        {
            if (Age < 1)
            {
                return "Возраст должен быть больше 0";
            }
            if (Age >= 100)
            {
                return "Возраст должен быть меньше 100";
            }
            return "";
        }

        public string Error
        {
            get
            {
                if(Validation1() == "" || Validation2() =="")
                {
                    return Validation1() + Validation2();
                }
                return Validation1() + ", \n" + Validation2();
            }
        }

        public string this[string columnName]
        {

            get
            {
                if ("Name" == columnName)
                {
                    return Validation1();
                }
                if ("Age" == columnName)
                {
                    return Validation2();
                }
                return "";
            }
        }


        private void Notify(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}