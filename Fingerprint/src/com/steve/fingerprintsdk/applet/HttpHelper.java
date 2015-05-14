/**
 * 
 */
package com.steve.fingerprintsdk.applet;

import java.io.IOException;
import java.io.InputStream;
import java.io.UnsupportedEncodingException;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.URLConnection;
import java.net.URLEncoder;

/**
 * @author Steve Teoh
 *
 */
public class HttpHelper {

	public HttpHelper(){ }
	
	public String httpEncode(String charset, String param1, String param1value) {
		if (charset == null) 
				charset = "UTF-8";
		
		// Or in Java 7 and later, use the constant:
		// java.nio.charset.StandardCharsets.UTF_8.name()

		try {
			String query = URLEncoder.encode(param1+ "=" + param1value, charset);
			return query;
		} catch (UnsupportedEncodingException e) {

			// TODO Auto-generated catch block
			e.printStackTrace();
			return "error";
		}
	}

	public Object httpGet(String url, String query, String charset) {
		URLConnection connection = null;
		if (charset == null) 
			charset = "UTF-8";
		
		try {
			connection = new URL(url + "?" + query).openConnection();
			connection.setRequestProperty("Accept-Charset", charset);
			connection.connect();
			Object obj = connection.getContent();

		} catch (MalformedURLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
			return null;

		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
			return null;
		}
		;
		try {
			InputStream response = connection.getInputStream();
			return response;      //gets response from server

		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
			return null;
		}
	}
}
