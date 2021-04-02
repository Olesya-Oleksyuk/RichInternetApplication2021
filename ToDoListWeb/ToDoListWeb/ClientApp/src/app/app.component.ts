import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { NoteModel } from './noteModel';
@Component({
    selector: 'app',
    templateUrl: `./app.component.html`,
    providers: [DataService]
})
export class AppComponent implements OnInit {
    note: NoteModel = new NoteModel();   // изменяемое примечание
    notes: NoteModel[];                // массив примечаниq
    tableMode: boolean = true;          // табличный режим

    constructor(private dataService: DataService) { }

    ngOnInit() {
        //this.loadProducts();    // загрузка данных при старте компонента  
    }
    // получаем данные через сервис
    //loadProducts() {
    //    this.dataService.getProducts()
    //        .subscribe((data: Product[]) => this.products = data);
    //}
    // сохранение данных
    save() {
        if (this.note.Id == null) {
            this.dataService.createNote(this.note)
                .subscribe((data: NoteModel) => this.notes.push(data));
        } else {
            //this.dataService.updateProduct(this.product)
            //    .subscribe(data => this.loadProducts());
        }
        this.cancel();
    }
    editNote(p: NoteModel) {
        this.note = p;
    }
    cancel() {
        this.note = new NoteModel();
        this.tableMode = true;
    }
    delete(p: NoteModel) {
        //this.dataService.deleteProduct(p.id)
        //    .subscribe(data => this.loadProducts());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
}