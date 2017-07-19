package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * �l���View�\�����Result
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/02/08 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceAccUserDispResult extends AbstractServiceResult
{
    /** �l���View�����f�[�^VO */
    private FindMasterMaintenanceAccUserVO _accUserVO = null;

    /**
     * �l���View�����f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _accUserVO
     */
    public void setAccUserVO(FindMasterMaintenanceAccUserVO vo)
    {
        _accUserVO = vo;
    }

    /**
     * �l���View�����f�[�^VO���擾���܂�
     * @return _accUserVO
     */
    public FindMasterMaintenanceAccUserVO getAccUserVO()
    {
        return _accUserVO;
    }

}
