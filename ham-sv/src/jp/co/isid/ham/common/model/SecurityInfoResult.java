package jp.co.isid.ham.common.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * セキュリティ情報Result
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/06/11 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class SecurityInfoResult extends AbstractServiceResult
{
    /** セキュリティ情報VOリスト */
    private List<SecurityInfoVO> _securityInfoVO;

    /**
     * セキュリティ情報VOリストを取得します
     * @return セキュリティ情報VOリスト
     */
    public List<SecurityInfoVO> getSecurityInfo()
    {
        return _securityInfoVO;
    }

    /**
     * セキュリティ情報VOリストを設定します
     * @param securityInfoVO セキュリティ情報VOリスト
     */
    public void setSecurityInfo(List<SecurityInfoVO> securityInfoVO)
    {
        _securityInfoVO = securityInfoVO;
    }


    /** ListだけではWebサービスに公開されないのでダミープロパティを追加 */
    private String _dummy;

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを追加を取得します
     * @return String ダミープロパティ
     */
    public String getDummy()
    {
        return _dummy;
    }

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを追加を設定します
     * @param dummy ダミープロパティ
     */
    public void setDummy(String dummy)
    {
        this._dummy = dummy;
    }

}
