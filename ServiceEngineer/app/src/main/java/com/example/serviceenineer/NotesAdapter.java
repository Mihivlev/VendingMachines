package com.example.serviceenineer;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import java.util.List;

public class NotesAdapter extends RecyclerView.Adapter<NotesAdapter.NoteVH> {
    Context context;
    List<Notes> ItemList;

    @NonNull
    @Override
    public NoteVH onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View v = LayoutInflater.from(context).inflate(R.layout.note, parent, false);
        return new NoteVH(v);
    }

    @Override
    public void onBindViewHolder(@NonNull NoteVH holder, int position) {
        holder.Title.setText(ItemList.get(position).getTitle());
        holder.Text.setText(ItemList.get(position).getText());
    }

    public void SetList(List<Notes> list){
        this.ItemList = list;
    }

    @Override
    public int getItemCount() {
        return ItemList.size();
    }

    public NotesAdapter(Context context1, List<Notes> eventsList) {
        context = context1;
        ItemList = eventsList;
    }

    public class NoteVH extends  RecyclerView.ViewHolder{
        TextView Title;
        TextView Text;
        public NoteVH(@NonNull View view){
            super(view);
            Title = view.findViewById(R.id.NoteTitle);
            Text = view.findViewById(R.id.NoteText);
        }
    }
}
