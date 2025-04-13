import { Component, Input, OnChanges, OnDestroy, OnInit } from '@angular/core';
import { Anthem } from '../models/anthem.model';
import { AnthemService } from '../services/anthem.service';

@Component({
  selector: 'app-show-info-anthems',
  templateUrl: './show-info-anthems.component.html',
  styleUrl: './show-info-anthems.component.css'
})
export class ShowInfoAnthemsComponent implements OnInit, OnChanges, OnDestroy {

  @Input() anthemId?: number;
  anthemInfo?:Anthem;
  private audio?: HTMLAudioElement;
  isPlaying: boolean = false;

  constructor(private anthemService: AnthemService) {

  }

  ngOnInit(){
    this.getAnthemInfo();
  }

  ngOnChanges(){
    this.getAnthemInfo();
  }

  // (good practice) stop hymn when component is destroyed
  ngOnDestroy() {
    this.stopAnthem();
  }

  getAnthemInfo():void {
    this.anthemService.getById(this.anthemId).subscribe({
      next: (data) => {

        this.stopAnthem(); // Stop anthem in curse

        this.anthemInfo = data;
      },
      error: (error) => {
        console.error('Error loading anthem: ', error);
      }
    });
  }

  playAnthem() {
    if (this.anthemInfo?.content) {
      // If an audio is already playing, pause it.
      if (this.audio) {
        this.audio.pause();
        this.audio.currentTime = 0;
      }
  
      // We create a new one and reproduce it
      this.audio = new Audio(this.anthemInfo.content);
      this.audio.play();
      this.isPlaying = true;
  
      // we use the end event to update the state
      this.audio.onended = () => {
        this.isPlaying = false;
      };
    }
  }
  
  pauseAnthem() {
    if (this.audio && this.isPlaying) {
      this.audio.pause();
      this.isPlaying = false;
    }
  }

  stopAnthem(){
    if(this.audio){
      this.audio.pause();
      this.audio.currentTime = 0;
      this.isPlaying = false;
    }
  }
}
