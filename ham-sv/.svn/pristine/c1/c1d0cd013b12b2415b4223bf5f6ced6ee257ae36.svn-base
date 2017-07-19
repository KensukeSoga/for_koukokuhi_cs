package jp.co.isid.ham.model.base;

import java.util.ArrayList;
import java.util.List;

import jp.co.isid.nj.exp.UserException;

/**
 *
 * <P>HAMエラークラス</P>
 * <P>
 * サーバ側処理で発生した業務的な例外を表すクラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2011/11/04 HLC sonobe)<BR>
 * </P>
 * @author HLC sonobe
 */
public class HAMException extends UserException {

    private static final long serialVersionUID = 3475726704676196349L;

    /** エラーID */
    private String _errorID;

    /** ノート */
    private List<String> _noteList = new ArrayList<String>();

    /**
    * 新規インスタンスを構築します<br>
    * messageはUIには戻されません<br>
    *
    * @param message message
    */
    public HAMException(String message) {
        super(message);
    }

    /**
    * 新規インスタンスを構築します<br>
    * messageはUIには戻されません<br>
    * UIには、errorIDに相当するメッセージが表示されます<br>
    *
    * @param message message
    * @param errorID errorID
    */
    public HAMException(String message, String errorID) {
        super(message);
        _errorID = errorID;
    }

    /**
    * 新規インスタンスを構築します
    *
    * @param cause 原因の例外
    */
    public HAMException(Throwable cause) {
        super(cause);
    }

    /**
    * 新規インスタンスを構築します
    *
    * @param message エラーメッセージ
    * @param cause 原因の例外
    */
    public HAMException(String message, Throwable cause) {
        super(message, cause);
    }

    /**
    * errorIDを戻します
    *
    * @return errorID
    */
    public String getErrorID() {
        return _errorID;
    }

    /**
    * errorIDをセットします
    * @param errorID errorID
    */
    public void setErrorID(String errorID) {
        _errorID = errorID;
    }

    /**
    * noteListを戻します
    *
    * @return noteList
    */
    public List<String> getNoteList() {
        return _noteList;
    }

    /**
    * noteListをセットします
    * @param noteList noteList
    */
    public void setNoteList(List<String> noteList) {
        _noteList = noteList;
    }

    /**
    * ノートを追加します
    * @param note note
    */
    public void addNote(String note) {
        _noteList.add(note);
    }
}