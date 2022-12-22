using System;
using System.Collections.Generic;
using System.Text;

namespace agam
{
    abstract class Person
    {
        const int VALID_BODY_TEMPERATURE = 38;

        protected string Name;
        protected int BodyTemperature;
        protected bool Isolated;
        protected bool HasMask;
        protected bool Covid19;


        public Person(bool PersonIsolated, bool PersonHasMask, string PersonName, int PersonBodyTemperature)
        {
            this.Isolated = PersonIsolated;
            this.HasMask = PersonHasMask;
            this.Name = PersonName;
            this.BodyTemperature = PersonBodyTemperature;
            this.Covid19 = false;
        }


        public bool getIsolated()
        {
            return this.Isolated;
        }




        public void setIsolated(bool setIsolated)
        {
            this.Isolated = setIsolated;
        }

        public bool getHasMask()
        {
            return this.HasMask;
        }

        public void setHasMask(bool setHasMask)
        {
            this.HasMask = setHasMask;
        }

        public string getName()
        {
            return this.Name;
        }

        public void setName(string setName)
        {
            this.Name = setName;
        }

        public int getBodyTemperature()
        {
            return this.BodyTemperature;
        }

        public void setBodyTemperature(int setBodyTemperature)
        {
            this.BodyTemperature = setBodyTemperature;
        }

        public bool getCovid()
        {
            return this.Covid19;
        }

        public void setCovid19(bool CovidStatus)
        {
            this.Covid19 = CovidStatus;
        }

        public bool allowToEnterAgaMacolet()
        {
            if (this.HasMask && (!this.Isolated) && this.BodyTemperature <= VALID_BODY_TEMPERATURE)
            {
                return true;
            }
            return false;
        }




    }
}
