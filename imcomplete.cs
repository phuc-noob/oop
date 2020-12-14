using System;
using System.Collections.Generic;
using System.Text;

namespace englishTest
{
    class imcomplete :multiQuestion
    {
        public imcomplete(string[] Pharagraph, List<multiChoise> Questions, int level)
        {
            this.paragraph = Pharagraph;
            this.questions = Questions;
            this.level = level;
        }
    }
}
