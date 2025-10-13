package com.example.serviceenineer;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Adapter;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AlertDialog;
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
        NotesAdapter.onNoteListener listener = new NotesAdapter.onNoteListener() {
            @Override
            public void onNoteListener(int id, String title) {
                Intent deleteNote = new Intent(context, DeletingActivity.class);
                deleteNote.putExtra("id",id);
                deleteNote.putExtra("name",title);
                startActivity(deleteNote);
            }
        };

        adapter = new NotesAdapter(context, notesList, listener);
        view.setAdapter(adapter);

        LoadData();
    }
    public void NewNote(View view){
        Intent modalNoteActivity = new Intent(context, ModalNote.class);
        startActivity(modalNoteActivity);
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

    @Override
    protected void onRestart() {
        super.onRestart();
        LoadData();
    }
}