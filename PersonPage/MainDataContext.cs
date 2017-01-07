﻿using PersonPage.DbLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonPage
{
     public class MainDataContext : INotifyPropertyChanged 
    {
        private string name = " ";
        private int age = 0;
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

        private void Notify(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
