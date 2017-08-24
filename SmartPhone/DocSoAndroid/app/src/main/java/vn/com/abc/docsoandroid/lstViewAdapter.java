package vn.com.abc.docsoandroid;

import android.app.Activity;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import java.util.ArrayList;

/**
 * Created by user on 18/08/2017.
 */

public class lstViewAdapter extends BaseAdapter {

    public ArrayList<lstViewEntity> list;
    Activity activity;

    public lstViewAdapter(Activity activity, ArrayList<lstViewEntity> list) {
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
        TextView txtName1;
        TextView txtName2;
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
            holder.txtName1 = (TextView) convertView.findViewById(R.id.lvName1);
            holder.txtName2 = (TextView) convertView.findViewById(R.id.lvName2);
            holder.txtContent = (TextView) convertView.findViewById(R.id.lvContent);
            convertView.setTag(holder);
        } else {
            holder = (ViewHolder) convertView.getTag();
        }

        lstViewEntity map = list.get(position);
        holder.txtID.setText(map.getID());
        holder.txtName1.setText(map.getName1());
        holder.txtName2.setText(map.getName2());
        holder.txtContent.setText(map.getContent());
        return convertView;
    }
}
