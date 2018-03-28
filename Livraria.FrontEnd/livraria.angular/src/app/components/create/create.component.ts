import { Component, OnInit } from '@angular/core';
import { Http, Response, } from '@angular/http';
import 'rxjs/add/operator/map';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {
  title = 'Cadastrar livro';
  private apiUrl = 'http://localhost:62847/api/livros';
  public Titulo:string = '';
  constructor( private http: Http) { 
    
  }

  Salvar(){
    console.log("Enviando o titulo =>" + this.Titulo);
    return this
    .http
    .post(this.apiUrl,
       {
         Titulo: this.Titulo
       }
      )
    .subscribe(
      data => {
        alert("Livro cadastrado com sucesso");
        this.Titulo = '';
    },
      error => {
        alert(error.json().Titulo)
      }
    );
  }
  ngOnInit() {
  }

  OnSubmit(){
    const req = this.Salvar();
  }
}
