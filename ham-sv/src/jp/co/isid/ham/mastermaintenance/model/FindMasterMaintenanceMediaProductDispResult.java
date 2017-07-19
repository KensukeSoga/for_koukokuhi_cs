package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * �}�́E���i�R�t�\�����Result
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/13 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceMediaProductDispResult extends AbstractServiceResult
{
    /** �}�́E���i�R�t�����f�[�^VO */
    private FindMbj27MediaProductVO _mediaProductVO = null;

    /** �Ԏ팟���f�[�^VO */
    private FindMbj05CarVO _carVO = null;

    /** �}�̌����f�[�^VO */
    private FindMbj03MediaVO _mediaVO = null;

    /** HC���匟���f�[�^VO */
    private FindMbj06HcBumonVO _hCSectionVO = null;

    /** HC���i�����f�[�^VO */
    private FindMbj08HcProductVO _hCProductVO = null;

    /**
     * �}�́E���i�R�t�����f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _mediaProductVO
     */
    public void setMediaProductVO(FindMbj27MediaProductVO vo)
    {
        _mediaProductVO = vo;
    }

    /**
     * �}�́E���i�R�t�����f�[�^VO���擾���܂�
     * @return _mediaProductVO
     */
    public FindMbj27MediaProductVO getMediaProductVO()
    {
        return _mediaProductVO;
    }

    /**
     * �Ԏ팟���f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _carVO
     */
    public void setCarVO(FindMbj05CarVO vo)
    {
        _carVO = vo;
    }

    /**
     * �Ԏ팟���f�[�^VO���擾���܂�
     * @return _carVO
     */
    public FindMbj05CarVO getCarVO()
    {
        return _carVO;
    }

    /**
     * �}�̌����f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _mediaVO
     */
    public void setMediaVO(FindMbj03MediaVO vo)
    {
        _mediaVO = vo;
    }

    /**
     * �}�̌����f�[�^VO���擾���܂�
     * @return _mediaVO
     */
    public FindMbj03MediaVO getMediaVO()
    {
        return _mediaVO;
    }

    /**
     * HC���匟���f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _hCSectionVO
     */
    public void setHCSectionVO(FindMbj06HcBumonVO vo)
    {
        _hCSectionVO = vo;
    }

    /**
     * HC���匟���f�[�^VO���擾���܂�
     * @return _hCSectionVO
     */
    public FindMbj06HcBumonVO getHCSectionVO()
    {
        return _hCSectionVO;
    }

    /**
     * HC���i�����f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _hCProductVO
     */
    public void setHCProductVO(FindMbj08HcProductVO vo)
    {
        _hCProductVO = vo;
    }

    /**
     * HC���i�����f�[�^VO���擾���܂�
     * @return _hCProductVO
     */
    public FindMbj08HcProductVO getHCProductVO()
    {
        return _hCProductVO;
    }

}
