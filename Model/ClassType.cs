using System;

namespace Model
{
    public class ClassType
    {
        /// <summary>
        /// 
        /// </summary>
        public int ID { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string ClassTypeName { set; get; }

        /// <summary>
        /// 是否是文科班，1：是（文科），0：否（理科）
        /// </summary>
        public int IsLiberalArts { set; get; }
    }
}
