package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 媒体・商品紐付表示登録データVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/13 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class RegistMasterMaintenanceMediaProductDispVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 媒体・商品紐付登録データVO */
    private RegistMbj27MediaProductVO _mediaProductVO = null;

    /**
     * デフォルトコンストラクタ
     */
    public RegistMasterMaintenanceMediaProductDispVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance()
    {
        return new RegistMasterMaintenanceMediaProductDispVO();
    }

    /**
     * 媒体・商品紐付登録データVOを設定します
     * @param vo セットする _mediaProductVO
     */
    public void setMediaProductVO(RegistMbj27MediaProductVO vo)
    {
        _mediaProductVO = vo;
    }

    /**
     * 媒体・商品紐付登録データVOを取得します
     * @return _mediaProductVO
     */
    public RegistMbj27MediaProductVO getMediaProductVO()
    {
        return _mediaProductVO;
    }

}
