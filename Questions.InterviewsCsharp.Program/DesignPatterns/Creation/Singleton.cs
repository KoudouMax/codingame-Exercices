using System;
namespace Questions.Interviews_CSharp.DesignPatterns.Creation;

public class WebServiceHelper
{
	private static readonly object s_ThreadSafety = new object();
	private static WebServiceHelper? s_Instance;

	public static WebServiceHelper Instance {
		get {
			if (s_Instance == null) {
				lock (s_ThreadSafety) {
					if (s_ThreadSafety == null) {
						s_Instance = new WebServiceHelper();
                    }
                }
            }
            return s_Instance;
        }
	}

    private WebServiceHelper(){}

	public static void ConnectToServer() {
		Console.WriteLine("App connecting to server...");
	}
}

