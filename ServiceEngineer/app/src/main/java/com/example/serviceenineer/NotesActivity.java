package com.example.serviceenineer;

import android.content.Context;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Adapter;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.RecyclerView;

import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class NotesActivity extends AppCompatActivity {
    Context context;
    NotesAdapter adapter;
    List<Notes> notesList = new ArrayList<Notes>();
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_notes);
        context = this;

        RecyclerView view = findViewById(R.id.RVNotes);
        adapter = new NotesAdapter(context, notesList);
        view.setAdapter(adapter);

        LoadData();
    }
    public void UpdateData(View view){
        LoadData();
    }
    public void LoadData(){
        Api.service.GetNotes(Api.user.getId()).enqueue(new Callback<List<Notes>>() {
            @Override
            public void onResponse(Call<List<Notes>> call, Response<List<Notes>> response) {
                    notesList = response.body();
                    if (notesList.size() > 0)
                    {
                        adapter.SetList(notesList);
                        adapter.notifyDataSetChanged();
                    }
                    else
                        Toast.makeText(context, "Ничего не найдено", Toast.LENGTH_LONG);
            }

            @Override
            public void onFailure(Call<List<Notes>> call, Throwable t) {
                Toast.makeText(context, t.toString(), Toast.LENGTH_LONG).show();
            }
        });
    }
}