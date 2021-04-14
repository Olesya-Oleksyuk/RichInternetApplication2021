import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NoteModel } from './noteModel';

@Injectable()
export class DataService {

    private url = "/home";
    
    constructor(private http: HttpClient) {
    }

    getNotes() {
        return this.http.get(this.url + '/GetNotes');
    }

    getNote(id: number) {
        return this.http.get(this.url + '/' + id);
    }

    createNote(note: NoteModel) {
        return this.http.post(this.url + '/AddNote', note);
    }
    updateNote(note: NoteModel) {

        return this.http.put(this.url, note);
    }
    deleteNote(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}