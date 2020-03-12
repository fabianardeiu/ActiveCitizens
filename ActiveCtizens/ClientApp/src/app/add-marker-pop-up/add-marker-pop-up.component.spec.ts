/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { AddMarkerPopUpComponent } from './add-marker-pop-up.component';

let component: AddMarkerPopUpComponent;
let fixture: ComponentFixture<AddMarkerPopUpComponent>;

describe('add-marker-pop-up component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ AddMarkerPopUpComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(AddMarkerPopUpComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});