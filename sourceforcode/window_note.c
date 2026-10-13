#include <windows.h>
#define ID_EDIT 1

LRESULT CALLBACK WindowProc(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam) 
{
    static HWND hEdit;

    switch (uMsg) 
    {
        case WM_CREATE:
            // This creates the big white text box
            hEdit = CreateWindow("EDIT", "",
                WS_CHILD | WS_VISIBLE | WS_VSCROLL | ES_MULTILINE | ES_AUTOVSCROLL,
                0, 0, 800, 600, hwnd, (HMENU)ID_EDIT, NULL, NULL);
            break;

        case WM_SIZE:
            MoveWindow(hEdit, 0, 0, LOWORD(lParam), HIWORD(lParam), TRUE);
            break;

        case WM_DESTROY:
            PostQuitMessage(0);
            break;
    }
    return DefWindowProc(hwnd, uMsg, wParam, lParam);
}

int WINAPI WinMain(HINSTANCE hInst, HINSTANCE hPrev, LPSTR lpCmd, int nShow) 
{
    WNDCLASS wc = {0};
    wc.lpfnWndProc = WindowProc;
    wc.hInstance = hInst;
    wc.lpszClassName = "-Notepad-";
    wc.hbrBackground = (HBRUSH)(COLOR_WINDOW+1);

    RegisterClass(&wc);
    HWND hwnd = CreateWindow("MyNotepad", "My Notepad - C", WS_OVERLAPPEDWINDOW, 100, 100, 800, 600, NULL, NULL, hInst, NULL);

    ShowWindow(hwnd, nShow);

    MSG msg;
    while (GetMessage(&msg, NULL, 0, 0)) 
    {
        TranslateMessage(&msg);
        DispatchMessage(&msg);
    }
    return 0;
}
