import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import { Http, Response, } from '@angular/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit {
  public title:string;
  public Codigo:number;
  public Titulo:string;
  private apiUrl = 'http://localhost:62847/api/livros';


  constructor(private route: ActivatedRoute,private http: Http, private router: Router) {
    
    this.route.params.subscribe( params => {
      this.Codigo = +params['id'];
      this.Titulo = params['titulo'];
    } );

    this.title = `Atualizar livro de código ${this.Codigo} - [${this.Titulo}]`;
  }

  OnSubmit(){
    this.Salvar();
  }
  Salvar(){
    return this
    .http
    .put(this.apiUrl,
       {
         Codigo: this.Codigo,
         Titulo: this.Titulo
       }
      )
    .subscribe(
      data => {
        console.log(data);
        alert("Livro atualizado com sucesso");
        this.Titulo = '';
        this.router.navigate(['/list']);
        
    },
      error => {
        let erro = error.json();
        let mensagem = erro.Titulo == undefined ? '' : erro.Titulo;
        mensagem += erro.Codigo == undefined ? '' : erro.Codigo;
        alert(mensagem);
      }
    );
  }
  ngOnInit() {
  }
}
