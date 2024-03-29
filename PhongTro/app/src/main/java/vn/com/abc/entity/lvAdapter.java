package vn.com.abc.entity;

import android.app.Activity;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import java.util.ArrayList;

import vn.com.abc.phongtro.R;

/**
 * Created by user on 18/08/2017.
 */

public class lvAdapter extends BaseAdapter {

    public ArrayList<lvEntity> list;
    Activity activity;

    public lvAdapter(Activity activity, ArrayList<lvEntity> list) {
        super();
        this.activity = activity;
        this.list = list;
    }

    @Override
    public int getCount() {
        return list.size();
    }

    @Override
    public Object getItem(int position) {
        return list.get(position);
    }

    @Override
    public long getItemId(int position) {
        return 0;
    }

    private class ViewHolder {
        TextView txtID;
        TextView txtName;
        TextView txtContent;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        ViewHolder holder;
        LayoutInflater inflater = activity.getLayoutInflater();
        if (convertView == null) {
            convertView = inflater.inflate(R.layout.custom_row_listview, null);
            holder = new ViewHolder();
            holder.txtID = (TextView) convertView.findViewById(R.id.lvID);
            holder.txtName = (TextView) convertView.findViewById(R.id.lvName);
            holder.txtContent = (TextView) convertView.findViewById(R.id.lvContent);
            convertView.setTag(holder);
        } else {
            holder = (ViewHolder) convertView.getTag();
        }

        lvEntity map = list.get(position);
        holder.txtID.setText(map.getID());
        holder.txtName.setText(map.getName());
        holder.txtContent.setText(map.getContent());
        return convertView;
    }
}
