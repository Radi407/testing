﻿using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Kontur.Courses.Testing.Patterns.Specifications
{
	public class MarkdownProcessor
	{

	    public string  Render(string input)
	    {
	        var emReplacer = new Regex(@"([^\w\\]|^)_(.*?[^\\])_(\W|$)");
	        var strongReplacer = new Regex(@"([^\w\\]|^)__(.*?[^\\])__(\W|$)");
	        input = strongReplacer.Replace(input,
	            match => match.Groups[1].Value +
	                     "<strong>" + match.Groups[2].Value + "</strong>" +
	                     match.Groups[3].Value);

	        input = emReplacer.Replace(input,
	            match => match.Groups[1].Value + "< em > " + match.Groups[2].Value + " </em >"  + match.Groups[3].Value);

	        input = input.Replace(@"\_", "_");
	        return input;
	    }
	}

	[TestFixture]
	public class MarkdownProcessor_should
	{
		private readonly MarkdownProcessor md = new MarkdownProcessor();

		//TODO see Markdown.txt
		
	}
}
