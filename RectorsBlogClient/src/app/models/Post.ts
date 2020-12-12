import { DatePipe } from '@angular/common';

export interface Post {
    postId: number;
    title: string;
    summary: string;
    body: string;
    imageUrl: string;
    userId?: number;
    userName?: string;
    creationDate: Date;
}