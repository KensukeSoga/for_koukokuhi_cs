package jp.co.isid.ham.login.model;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

//import jp.co.isid.ham.mastermaintenance.model.Mhf31TntVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
*
* <P>
* 業務会計セキュリティロールを保持する
* </P>
* <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/05/17 JSE K.Tamura)<BR>
 * </P>
 * @author JSE K.Tamura
*/
@XmlRootElement(namespace = "http://model.login.cnp.isid.co.jp/")
@XmlType(namespace = "http://model.login.cnp.isid.co.jp/")
public class AccountSecurityRoleResult extends AbstractServiceResult {

    /** 相対権限 */
    private String _relativeAuthority = null;

    /** セキュリティロール取得対象外フラグ */
    private boolean _notSecurityRoleFlag = false;

//    /** 管理者ユーザー情報 */
//    private Mhf31TntVO _kanriUserInfo = null;

    /**
     * 相対権限を取得する
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
        this._relativeAuthority = relativeAuthority;
    }

    /**
     * セキュリティロール取得対象外フラグを取得する
     * @return セキュリティロール取得対象外フラグ
     */
    @XmlElement(required = true)
    public boolean getNotSecurityRoleFlag() {
        return _notSecurityRoleFlag;
    }

    /**
     * セキュリティロール取得対象外フラグを設定する
     * @param notSecurityRoleFlag セキュリティロール取得対象外フラグ
     */
    public void setNotSecurityRoleFlag(boolean notSecurityRoleFlag) {
        this._notSecurityRoleFlag = notSecurityRoleFlag;
    }

//    /**
//     * 管理者ユーザー情報を取得する
//     * @return 管理者ユーザー情報の権限
//     */
//    public Mhf31TntVO getKanriUserInfo() {
//        return _kanriUserInfo;
//    }
//
//    /**
//     * 管理者ユーザー情報を設定する
//     * @param kanriUserKengen 管理者ユーザー情報の権限
//     */
//    public void setKanriUserInfo(Mhf31TntVO kanriUserInfo) {
//        this._kanriUserInfo = kanriUserInfo;
//    }

}
