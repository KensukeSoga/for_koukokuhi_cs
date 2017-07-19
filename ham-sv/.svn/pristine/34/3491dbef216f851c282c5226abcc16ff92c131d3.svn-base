package jp.co.isid.ham.service.base;

import java.util.ArrayList;
import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 *
 * <P>エラー情報クラス</P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2010/12/06 ISID-IT K.Nukita)<BR>
 * </P>
 * @author ISID-IT K.Nukita
 */
@XmlRootElement(namespace = "http://model.ham.isid.co.jp/")
@XmlType(namespace = "http://model.ham.isid.co.jp/")
public class ErrorInfo {

    /** エラーか否か */
    private boolean _error;

    /** エラーコード */
    private String _errorCode;

    /** 備考 */
    private List<String> _note;

    /**
     * コンストラクタ
     *
     */
    public ErrorInfo() {
    }

    /**
     * エラーか否かを取得します
     * @return エラーか否か
     */
    public boolean isError() {
        return _error;
    }

    /**
     * エラーか否かを設定します
     * @param error エラーか否か
     */
    public void setError(boolean error) {
        this._error = error;
    }

    /**
     * エラーコードを取得します
     * @return エラーコード
     */
    public String getErrorCode() {
        return _errorCode;
    }

    /**
     * エラーコードを設定します
     * @param errorCode エラーコード
     */
    public void setErrorCode(String errorCode) {
        this._errorCode = errorCode;
    }

    /**
     * 備考を取得します
     * @return List<String>オブジェクト
     */
    public List<String> getNote() {
        if (_note == null) {
            _note = new ArrayList<String>();
        }
        return _note;
    }

    /**
     *備考を設定します
     * @param note 備考
     */
    public void setNote(List<String> note) {
        _note = note;
    }

}
