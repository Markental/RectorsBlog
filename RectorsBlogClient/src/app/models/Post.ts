export interface Post {
    id: number;
    title: string;
    summary: string;
    body: string;
    imageUrl: string;
    userId?: number;
    userName?: string;
}