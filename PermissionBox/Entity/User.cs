using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PermissionBox.Entity;
using PermissionBox.Dapper;

namespace PermissionBox.Entity
{
    public class User
    {
        public int ID { set; get; }

        /// <summary>
        /// 1.准考证号
        /// </summary>
        public string ExaminationCardNumber { set; get; }

        /// <summary>
        /// 2.姓名
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 3.报名地州
        /// </summary>
        public string RegistrationState { set; get; }

        /// <summary>
        /// 4.报名县市
        /// </summary>
        public string RegistrationCity { set; get; }

        /// <summary>
        /// 5.报名学校
        /// </summary>
        public string RegistrationSchool { set; get; }

        /// <summary>
        /// 6.报名户口地州
        /// </summary>
        public string HouseholdState { set; get; }

        /// <summary>
        /// 7.实际生源地州
        /// </summary>
        public string StudentState { set; get; }

        /// <summary>
        /// 8.语文成绩
        /// </summary>
        public float Chinese { set; get; }

        /// <summary>
        /// 9.物理、化学成绩
        /// </summary>
        public float PhysicsOrChemistry { set; get; }

        /// <summary>
        /// 10.数学成绩
        /// </summary>
        public float Mathematics { set; get; }

        /// <summary>
        /// 11.道德与法治、历史成绩
        /// </summary>
        public float PoliticsOrHistory { set; get; }

        /// <summary>
        /// 12.外语成绩
        /// </summary>
        public float ForeignLanguage { set; get; }

        /// <summary>
        /// 13.总成绩
        /// </summary>
        public float Total { set; get; }

        /// <summary>
        /// 14.体育是否合格
        /// Y：合格，N：不合格
        /// </summary>
        public string PE { set; get; }

        /// <summary>
        /// 15.证件号
        /// </summary>
        public string IDCard { set; get; }

        /// <summary>
        /// 16.学籍号
        /// </summary>
        public string StudentStatusCode { set; get; }

        /// <summary>
        /// 17.生源
        /// </summary>
        public string StudentSource { set; get; }

        /// <summary>
        /// 18.族别
        /// </summary>
        public string Nationality { set; get; }

        /// <summary>
        /// 19.性别
        /// </summary>
        public string Gender { set; get; }

        /// <summary>
        /// 20.出生日期
        /// </summary>
        public DateTime BirthDate { set; get; }

        /// <summary>
        /// 21.班级
        /// </summary>
        public string Class { set; get; }

        /// <summary>
        /// 22.考生特征
        /// </summary>
        public string StudentCharacteristics { set; get; }

        /// <summary>
        /// 23.政治面貌
        /// </summary>
        public string PoliticalAffiliation { set; get; }

        /// <summary>
        /// 24.户口性质
        /// </summary>
        public string HouseholdType { set; get; }

        /// <summary>
        /// 25.通讯地址
        /// </summary>
        public string Address { set; get; }

        /// <summary>
        /// 26.联系电话
        /// </summary>
        public string PhoneNumber { set; get; }

        /// <summary>
        /// 27.邮政编码
        /// </summary>
        public string PostalCode { set; get; }

        /// <summary>
        /// 28.父亲姓名
        /// </summary>
        public string FatherName { set; get; }

        /// <summary>
        /// 29.父亲身份证号
        /// </summary>
        public string FatherIDCard { set; get; }

        /// <summary>
        /// 30.父亲族别
        /// </summary>
        public string FatherNationality { set; get; }

        /// <summary>
        /// 31.父亲户口性质
        /// </summary>
        public string FatherHouseholdType { set; get; }

        /// <summary>
        /// 32.父亲联系电话
        /// </summary>
        public string FatherPhoneNumber { set; get; }

        /// <summary>
        /// 33.父亲工作单位
        /// </summary>
        public string FatherOccupation { set; get; }

        /// <summary>
        /// 34.母亲姓名
        /// </summary>
        public string MotherName { set; get; }

        /// <summary>
        /// 35.母亲身份证号
        /// </summary>
        public string MatherIDCard { set; get; }

        /// <summary>
        /// 36.母亲族别
        /// </summary>
        public string MotherNationality { set; get; }

        /// <summary>
        /// 37.母亲户口性质
        /// </summary>
        public string MotherHouseholdType { set; get; }

        /// <summary>
        /// 38.母亲联系电话
        /// </summary>
        public string MotherPhoneNumber { set; get; }

        /// <summary>
        /// 39.母亲工作单位
        /// </summary>
        public string MotherOccupation { set; get; }

        /// <summary>
        /// 40.录取省事
        /// </summary>
        public string AdmissionProvince { set; get; }

        /// <summary>
        /// 41.录取学校
        /// </summary>
        public string AdmissionSchool { set; get; }


        public int IsDelete { set; get; }

    }
}
