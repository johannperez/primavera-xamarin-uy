package com.example.monkeys.monkeydevs;

import android.content.Context;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.AttributeSet;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import monkeyssdk.droid.*;


public class MainActivity extends AppCompatActivity {

    private TextView resultsTextView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        resultsTextView = findViewById(R.id.restultTextView);

        Button randomMonkeySyncButton = findViewById(R.id.getRandomMonkeySyncButton);
        randomMonkeySyncButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                resultsTextView.setText(new MonkeysSDK().getRandomMonkey());
            }
        });

        Button randomMonkeyAsyncButton = findViewById(R.id.getRandomMonkeyAsyncButton);
        randomMonkeyAsyncButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                new GetRandomMonkeyAsyncTask().execute();
            }
        });

        Button getmonkeysButton = findViewById(R.id.getMonkeysButton);
        getmonkeysButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                new GetMonkeysAsyncTask().execute();
            }
        });

        Button dontTouchButton = findViewById(R.id.dontTouchButton);
        dontTouchButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                try {
                    new MonkeysSDK().fireMonkeyBomb();
                }
                catch (Exception ex)
                {
                    resultsTextView.setText("An error ocurred, contact your admin somehow");
                }
            }
        });
    }

    class GetRandomMonkeyAsyncTask extends AsyncTask<Void, Void, String>{
        @Override
        protected String doInBackground(Void... voids) {
            return new MonkeysSDK().getRandomMonkey();
        }

        @Override
        protected void onPostExecute(String randomMonkey) {
            resultsTextView.setText(randomMonkey);
        }
    }

    class GetMonkeysAsyncTask extends AsyncTask<Void, Void, String>{
        @Override
        protected String doInBackground(Void... voids) {
            MonkeyIterator monkeys = new MonkeysSDK().getMonkeyIterator();

            String monkeysString = monkeys.getFirst().getName();

            while(monkeys.getNext() != null)
            {
                monkeysString += ", " + monkeys.getCurrent().getName();
            }

            return  monkeysString;
        }

        @Override
        protected void onPostExecute(String monkeysString) {
            resultsTextView.setText(monkeysString);
        }
    }

}
