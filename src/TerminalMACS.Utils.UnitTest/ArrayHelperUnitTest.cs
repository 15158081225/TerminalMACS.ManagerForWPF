using System;
using TerminalMACS.Utils.NetObjectHelper;
using TerminalMACS.Utils.UnitTest.Models;
using Xunit;
using Xunit.Abstractions;

namespace TerminalMACS.Utils.UnitTest
{
    public class ArrayHelperUnitTest
    {
        public ArrayHelperUnitTest(ITestOutputHelper testOutput)
        {
            _output = testOutput;
        }

        private readonly ITestOutputHelper _output = null;

        [Fact]
        public void Test1()
        {
            // Arrange
            ThreeCountries shuKingdom = new ThreeCountries
            {
                ID = 1,
                Name = "���",
                Emperor = "����",
                Courses = new System.Collections.Generic.List<FamousGeneral>
                {
                    new FamousGeneral{ ID=1,Name="�ŷ�",Memo="���師"},
                    new FamousGeneral{ ID=2,Name="����",Memo="�������µ�"},
                    new FamousGeneral{ ID=3,Name="����",Memo="���͵�"},
                    new FamousGeneral{ ID=3,Name="��",Memo="ǿ"},
                    new FamousGeneral{ ID=3,Name="����",Memo="�ϵ���׳"},
                }
            };
            _output.WriteLine($"���Զ���===={shuKingdom}");

            // act
            var arrs = NetObjectSerializeHelper.Serialize(shuKingdom);
            _output.WriteLine($"���л����ֽڳ��ȣ�===={arrs.Length}");

            var student2 = NetObjectSerializeHelper.Deserialize<ThreeCountries>(arrs);
            _output.WriteLine($"�����л������===={student2}");

            // Assert
            Assert.Equal(shuKingdom.ID, student2.ID);
            Assert.Equal(shuKingdom.Name, student2.Name);
            _output.WriteLine("���л��������л�����ͨ��");
        }
    }
}
