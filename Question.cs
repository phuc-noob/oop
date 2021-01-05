using System;
using System.Collections.Generic;
using System.Text;

namespace englishTest
{
    enum DanhMuc
    {
        DanhTu,
        DongTu,
        TinhTu,
        TrangTu,
        GioiTu,
        DanhMucKhac,
    }
    class Question
    {
        protected DanhMuc danhMuc;
        protected int level;
        protected int id;
        protected float mark;
        public float Mark{
            get{ return this.mark; }    
        }
        public Question() { }
        public Question(string danhMuc, int level ,int id,float mark)
        {
            this.level = level;
            this.id = id;
            this.mark = mark;
        }

        public int Level
        {
            get { return this.level; }
        }
        public int Id
        {
            get { return this.id; }
        }
        public DanhMuc DanhMuc
        {
            get { return this.danhMuc; }
        }
    }
}
