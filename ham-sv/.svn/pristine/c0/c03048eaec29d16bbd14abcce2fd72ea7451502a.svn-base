package jp.co.isid.ham.login.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;


@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class MprKengenCheckResult extends AbstractServiceResult {

    /**
     * 営業所コード
     */
    private String _egsCd = null;

    /**
     * 相対権限
     */
    private String _relativeAuthority = null;

    /**
     * MPR権限チェック結果
     */
    private boolean _checkResult = false;

    /**
     * 営業所コードを取得する
     *
     * @return _egsCd
     */
    public String getEgsCd() {
        return _egsCd;
    }

    /**
     * 営業所コードを設定する
     * @param egsCd _egsCd
     */
    public void setEgsCd(String egsCd) {
        _egsCd = egsCd;
    }

    /**
     * 相対権限を取得する
     *
     * @return 相対権限
     */
    public String getRelativeAuthority() {
        return _relativeAuthority;
    }

    /**
     * 相対権限を設定する
     * @param relativeAuthority 相対権限
     */
    public void setRelativeAuthority(String relativeAuthority) {
        _relativeAuthority = relativeAuthority;
    }

    /**
     * MPR権限チェック結果を取得する
     *
     * @return MPR権限チェック結果
     */
    public boolean getCheckResult() {
        return _checkResult;
    }

    /**
     * MPR権限チェック結果を設定する
     * @param checkResult MPR権限チェック結果
     */
    public void setCheckResult(boolean checkResult) {
        _checkResult = checkResult;
    }
}
