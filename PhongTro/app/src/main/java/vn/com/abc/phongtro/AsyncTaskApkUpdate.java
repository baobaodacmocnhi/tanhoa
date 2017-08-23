package vn.com.abc.phongtro;

import android.os.AsyncTask;
import android.os.Environment;

import java.io.BufferedInputStream;
import java.io.DataOutputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.URL;
import java.net.URLConnection;

/**
 * Created by user on 19/08/2017.
 */
//String url = "http://myawesomesite.com/api/protected/apk";
//
//        new ApkUpdateAsyncTask().execute(url);
public class AsyncTaskApkUpdate extends AsyncTask<String,Void,String>{
    @Override
    protected String doInBackground(String... params) {
        String path = Environment.getExternalStorageDirectory()+"/awesomeapp.apk";

        //download the apk from your server and save to sdk card here
        try{
            URL url = new URL(params[0]);
            URLConnection connection = url.openConnection();
            connection.connect();

            // download the file
            InputStream input = new BufferedInputStream(url.openStream());
            OutputStream output = new FileOutputStream(path);

            byte data[] = new byte[1024];
            int count;
            while ((count = input.read(data)) != -1)
            {
                output.write(data, 0, count);
            }

            output.flush();
            output.close();
            input.close();
        }catch(Exception e){}

        return path;
    }

    @Override
    protected void onPostExecute(String path)
    {
        Process process = null;

        // call to superuser command, pipe install updated APK without writing over files/DB
        try
        {
            process = Runtime.getRuntime().exec("su");
            DataOutputStream outs = new DataOutputStream(process.getOutputStream());

            String cmd = "pm install -r "+path;

            outs.writeBytes(cmd+"\\n");
        }
        catch (IOException e)
        {}
    }
}
