package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 新聞マスタ表示登録データVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/09/17 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class RegistMasterMaintenanceNewspaperDispVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 新聞マスタ登録データVO */
    private RegistMbj47NewspaperVO _newspaperVO = null;

    /**
     * デフォルトコンストラクタ
     */
    public RegistMasterMaintenanceNewspaperDispVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance()
    {
        return new RegistMasterMaintenanceNewspaperDispVO();
    }

    /**
     * 新聞マスタ登録データVOを設定します
     * @param vo セットする _newspaperVO
     */
    public void setNewspaperVO(RegistMbj47NewspaperVO vo)
    {
        _newspaperVO = vo;
    }

    /**
     * 新聞マスタ登録データVOを取得します
     * @return _newspaperVO
     */
    public RegistMbj47NewspaperVO getNewspaperVO()
    {
        return _newspaperVO;
    }

}
