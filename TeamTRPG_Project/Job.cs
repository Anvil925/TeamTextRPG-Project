﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTRPG_Project
{
    public class Job
    {
        public string Name { get; set; }
        public Jobs JobType { get; set; }

        // 전직 시 추가 능력치
        public float ATK { get; set; }      // 공격력
        public float DEF { get; set; }      // 방어력
        public float MAX_HP { get; set; }   // 최대 체력

        public Job(string name, Jobs job, float atk, float def, float max_HP)
        {
            Name = name;
            JobType = job;
            ATK = atk;
            DEF = def;
            MAX_HP = max_HP;
        }

        public static List<Job> JobList = new List<Job>()
        {
            new Job("기획", Jobs.PLANNING, 5, 5, 50),
            new Job("개발", Jobs.PLANNING, 8, 3, 50),
            new Job("디자이너", Jobs.PLANNING, 3, 8, 50)
        };
    }
}
