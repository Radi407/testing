using System;
using Kontur.Courses.Testing.Implementations;
using NUnit.Framework;

namespace Kontur.Courses.Testing
{
	public class WordsStatistics_Tests
	{
		public Func<IWordsStatistics> createStat = () => new WordsStatistics_CorrectImplementation(); // меняется на разные реализации при запуске exe
		public IWordsStatistics stat;

		[SetUp]
		public void SetUp()
		{
			stat = createStat();
		}

		[Test]
		public void no_stats_if_no_words()
		{
			CollectionAssert.IsEmpty(stat.GetStatistics());
		}

		[Test]
		public void same_word_twice()
		{
			stat.AddWord("xxx");
			stat.AddWord("xxx");
			CollectionAssert.AreEqual(new[] { Tuple.Create(2, "xxx") }, stat.GetStatistics());
		}

		[Test]
		public void single_word()
		{
			stat.AddWord("hello");
			CollectionAssert.AreEqual(new[] { Tuple.Create(1, "hello") }, stat.GetStatistics());
		}

		[Test]
		public void two_same_words_one_other()
		{
			stat.AddWord("hello");
			stat.AddWord("world");
			stat.AddWord("world");
			CollectionAssert.AreEqual(new[] { Tuple.Create(2, "world"), Tuple.Create(1, "hello") }, stat.GetStatistics());
		}

	    [Test]
	    public void Test1()
	    {
	        stat.AddWord("ab");
	        stat.AddWord("bc");
	        stat.AddWord("bc");
            stat.AddWord("abc");
            stat.AddWord("abc");
            CollectionAssert.AreEqual(new[] { Tuple.Create(2, "abc"),Tuple.Create(2 , "bc"), Tuple.Create(1, "ab") }, stat.GetStatistics());
	    }

        [Test]
        public void Test2()
        {
            for (int i = 0; i < 50; i++)
                stat.AddWord("ccc");
            for (int i = 0; i < 100; i++)
                stat.AddWord("aaa");
            CollectionAssert.AreEqual(new[] { Tuple.Create(100, "aaa"), Tuple.Create(50, "ccc") }, stat.GetStatistics());
        }


        [Test]
        public void Test3()
        {
            stat.AddWord("abd");
            stat.AddWord("ABD");
            CollectionAssert.AreEqual(new[] { Tuple.Create(2, "abd") }, stat.GetStatistics());
        }


        [Test]
        public void Test4()
        {
            stat.AddWord("aaaaaaaaaaaaaaaaaaaaaaaaaabbb");
            stat.AddWord("aaaaaaaaaaaaaaaaa");
            stat.AddWord("aaaaaaa");
            CollectionAssert.AreEqual(new[] { Tuple.Create(2, "aaaaaaaaaa"),Tuple.Create(1,"aaaaaaa") }, stat.GetStatistics());
        }

	    [Test]
	    public void Test5()
	    {
	        stat.AddWord("");
            stat.AddWord("a");
            CollectionAssert.AreEqual(new[] { Tuple.Create(1, "a") }, stat.GetStatistics());
	    }

        [Test]
	    public void Test6()
	    {
            stat.AddWord("12345678911");
            stat.AddWord("12345678910");
            stat.AddWord("123456789");
            CollectionAssert.AreEqual(new[] { Tuple.Create(2, "1234567891"), Tuple.Create(1, "123456789") }, stat.GetStatistics());
	        
	    }


        
	}
}