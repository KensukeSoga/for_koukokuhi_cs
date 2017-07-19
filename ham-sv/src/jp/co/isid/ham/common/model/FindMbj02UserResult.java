package jp.co.isid.ham.common.model;


import java.util.List;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * 担当者マスタResult
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/07/25 藤吉)<BR>
 * </P>
 * @author 藤吉
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMbj02UserResult extends AbstractServiceResult {

    /** 担当者マスタ */
    private List<Mbj02UserVO> _userVo;

    /**
     * 担当者マスタVOリストを取得します
     * @return 担当者マスタVO
     */
    public List<Mbj02UserVO> getUserVo()
    {
        return _userVo;
    }

    /**
     * 担当者マスタVOリストを設定します
     * @param userVo 担当者マスタ
     */
    public void setUserVo(List<Mbj02UserVO> userVo)
    {
        _userVo = userVo;
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
