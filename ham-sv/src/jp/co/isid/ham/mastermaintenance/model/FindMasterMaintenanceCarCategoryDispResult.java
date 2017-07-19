package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * 車種カテゴリ表示情報Result
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/12 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceCarCategoryDispResult extends AbstractServiceResult
{
    /** 車種カテゴリ検索データVO */
    private FindMbj20CarCategoryVO _carCategoryVO = null;

    /**
     * 車種カテゴリ検索データVOを設定します
     * @param vo セットする _carCategoryVO
     */
    public void setCarCategoryVO(FindMbj20CarCategoryVO vo)
    {
        _carCategoryVO = vo;
    }

    /**
     * 車種カテゴリ検索データVOを取得します
     * @return _carCategoryVO
     */
    public FindMbj20CarCategoryVO getCarCategoryVO()
    {
        return _carCategoryVO;
    }

}
