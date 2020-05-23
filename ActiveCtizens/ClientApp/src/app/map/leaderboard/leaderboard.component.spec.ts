/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { LeaderboardComponent } from './leaderboard.component';

let component: LeaderboardComponent;
let fixture: ComponentFixture<LeaderboardComponent>;

describe('leaderboard component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ LeaderboardComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(LeaderboardComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});