package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * 入力担当表示情報Result
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/13 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceInputUserDispResult extends AbstractServiceResult
{
    /** 入力担当検索データVO */
    private FindMbj30InputTntVO _inputUserVO = null;

    /** 車種検索データVO */
    private FindMbj05CarVO _carVO = null;

    /**
     * 入力担当検索データVOを設定します
     * @param vo セットする _inputUserVO
     */
    public void setInputUserVO(FindMbj30InputTntVO vo)
    {
        _inputUserVO = vo;
    }

    /**
     * 入力担当検索データVOを取得します
     * @return _inputUserVO
     */
    public FindMbj30InputTntVO getInputUserVO()
    {
        return _inputUserVO;
    }

    /**
     * 車種検索データVOを設定します
     * @param vo セットする _carVO
     */
    public void setCarVO(FindMbj05CarVO vo)
    {
        _carVO = vo;
    }

    /**
     * 車種検索データVOを取得します
     * @return _carVO
     */
    public FindMbj05CarVO getCarVO()
    {
        return _carVO;
    }

}
