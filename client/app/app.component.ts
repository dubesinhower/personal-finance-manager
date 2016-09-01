import { Component } from '@angular/core';
import {FILE_UPLOAD_DIRECTIVES, FileUploader, FileSelectDirective} from 'ng2-file-upload/ng2-file-upload';

const URL = '';

@Component({
    selector: 'my-app',
    templateUrl: './app/app.component.html',
    directives: [FileSelectDirective]
})
export class AppComponent {
    public uploader:FileUploader = new FileUploader({url: URL});
}